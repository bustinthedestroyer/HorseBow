using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Entities;

public class LevelController : MonoBehaviour {

    public Text TextLevelTitle;
    public Text TextLevelStatus;

    public Text TextScore;
    public Text TextHighScore;
    public Text TextPlayerLevel;

    public Slider HealthSlider;
    public Slider ExperienceSlider;

    
    private int currentHealth;
    public int CurrentScore;


    private bool IsGameOver = false;

    public AudioSource level1Music;
    public AudioSource level2Music;
    public AudioSource level3Music;
    public AudioSource playerHit;


    public CameraController cameraController;
    public PlayerController playerController;
    public MenuController menuController;
    public EnemyController enemyController;
    

    bool damaged = false;
    Color damagedColor = new Color(.5f,0,0,1f);
    float damageFadeTimer = 2.5f;
	public Image BloodFade;


	private void Start()
    {

        //PlayerModel.Reset();
        PlayerModel.Load();

        currentHealth = PlayerModel.Health;
        HealthSlider.maxValue = currentHealth;
        HealthSlider.value = currentHealth;
        
        TextPlayerLevel.text = "lvl: " + PlayerModel.Level.ToString();
        ExperienceSlider.minValue = PlayerModel.NextLevel - (PlayerModel.Level * PlayerModel.levelFactor);
        ExperienceSlider.maxValue = PlayerModel.NextLevel;
        ExperienceSlider.value = PlayerModel.ExperiencePoints;

        StartCoroutine(TextFade(TextLevelStatus, "Get Ready!"));
        TextLevelTitle.text = "Get Ready!";

        TextHighScore.text = PlayerModel.HighScore.ToString();
        TextScore.text = "0";

        StartCoroutine(PlayGame());
    }

    private void Update()
    {
        if(damaged){
            BloodFade.color = damagedColor;
        }else{
            BloodFade.color = Color.Lerp(BloodFade.color, Color.clear, damageFadeTimer*Time.deltaTime);
        }
        damaged = false;
    }

    private int bossLevels = 5;
    public int WaveNumber = 0;

    IEnumerator PlayGame(){

        ChangeMusic();
        WaveNumber = PlayerModel.Level;


        while(true){


            ////////
            ////Wave
            ////////


            ////Wait for prev wave
            yield return new WaitForSeconds(2);
            playerController.firing = true;

            //// Boss every other level
            if (WaveNumber % bossLevels == 0 ){
                
                ChangeMusic();
                ////Update Text
                string waveText = "Boss Wave " + WaveNumber.ToString();
                StartCoroutine(TextFade(TextLevelStatus, waveText));
                TextLevelTitle.text = waveText;

                GameObject _segmentEnemy = enemyController.DarkHorse;
                EnemyCountTotal = WaveNumber / bossLevels;
                ////GetFormation
                Vector2[] bossSpawn = enemyController.GetSpawnPositions(false, enemyController.GetRandomFormation(), EnemyCountTotal);

                for(int e=0;e<EnemyCountTotal;e++){
                    Instantiate(_segmentEnemy, bossSpawn[e], transform.rotation);
                }

                yield return new WaitUntil(AllBadGuysAreDead);

            }else{

                ////Update Text
                string waveText = "Wave " + WaveNumber.ToString();
                StartCoroutine(TextFade(TextLevelStatus, waveText));
                TextLevelTitle.text = waveText;

                ////How many segments this wave
                int minSegments = Random.Range(1,2);
                int waveBonusSegments = Mathf.CeilToInt(WaveNumber*.2f);
                int levelBonusSegments = Mathf.CeilToInt(WaveNumber*.1f);
                int segments = minSegments + waveBonusSegments + levelBonusSegments;

                ////Each Segment
                for(int s=0;s<segments;s++){
                    ////Wait for prev segment
                    yield return new WaitForSeconds(.5f);

                    ////EnemyType

                    GameObject _segmentEnemy = enemyController.GetRandomEnemy();
                    Enemy enemyScript = _segmentEnemy.GetComponent<Enemy>();

                    ////Number of enemeis in each segment
                    int enemyCountMin= Random.Range(2,3);
                    int enemyCountWaveBonus = Mathf.CeilToInt(WaveNumber*.4f);
                    int enemyCountLevelBonus = Mathf.CeilToInt(WaveNumber*.3f);
                    EnemyCountTotal = enemyCountMin + enemyCountWaveBonus + enemyCountLevelBonus;
                    
                    ////GetFormation
                    Vector2[] enemySpawns = enemyController.GetSpawnPositions(enemyScript.Flying, enemyController.GetRandomFormation(), EnemyCountTotal);

                    for(int e=0;e<EnemyCountTotal;e++){
                        ////Spawn badguys.
                        Instantiate(_segmentEnemy, enemySpawns[e], transform.rotation);

                    }

                    yield return new WaitUntil(AllBadGuysAreDead);
                }

            }

            if(IsGameOver){
                break;
                
            }

            WaveNumber++;
        }
    }

    public int EnemyCountTotal = 0; 
    public bool AllBadGuysAreDead(){
        return EnemyCountTotal <= 0 ? true : false;
    }

    public void ChangeMusic(){

        level1Music.Stop();
        level2Music.Stop();
        level3Music.Stop();

        int nextSong = Random.Range(0,3);
        switch(nextSong){
            case 1:
                level1Music.Play();
                break;
            case 2:
                level2Music.Play();
                break;
            case 3:
                level3Music.Play();
                break;
            default:
                level1Music.Play();
                break;            
        }
    }

    IEnumerator TextFade(Text textElement, string text){
            textElement.text = text;
            yield return new WaitForSeconds(1.5f);
            textElement.text = "";
    }  

    void GameOver(){
        IsGameOver = true;
        playerController.Die();
        StartCoroutine(TextFade(TextLevelStatus, "You died homie."));
        PlayerModel.Save();
        menuController.GoToMenu();
    }

    public void Score(int points)
    {
        ////Add score
        CurrentScore += points;
        TextScore.text = CurrentScore.ToString();

        ////Did we break the high score record?
        if(CurrentScore > PlayerModel.HighScore)
        {
            PlayerModel.HighScore = CurrentScore;
            TextHighScore.text = CurrentScore.ToString();
        }

        ////Gain Experience
        PlayerModel.ExperiencePoints += points;
        ExperienceSlider.value = PlayerModel.ExperiencePoints;

        ////Did we level up?
        if(PlayerModel.ExperiencePoints > PlayerModel.NextLevel){
            PlayerModel.Level++;
            PlayerModel.TalentPoints++;
            PlayerModel.NextLevel = PlayerModel.Level * PlayerModel.levelFactor + PlayerModel.NextLevel;
            ExperienceSlider.minValue = PlayerModel.NextLevel - (PlayerModel.Level * PlayerModel.levelFactor);
            ExperienceSlider.maxValue = PlayerModel.NextLevel;
            TextPlayerLevel.text = "lvl: " + PlayerModel.Level.ToString();
        }
    }

    public void TakeDamage()
    {
        if(!IsGameOver)
        {
            damaged = true;
            cameraController.ShakeCamera(0.1f, .25f);
            playerHit.Play();
            currentHealth--;
            HealthSlider.value = currentHealth;
            if(currentHealth == 0){
                GameOver();
            }
        }
    }

}