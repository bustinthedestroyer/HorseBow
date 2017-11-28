// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using Entities;


// public class LevelController1 : MonoBehaviour {

//     public Text TextLevelTitle;
//     public Text TextLevelStatus;

//     public Text TextScore;
//     public Text TextHighScore;

//     public Slider HealthSlider;

//     public GameObject FootSoldier;
//     public GameObject FastSoldier;
//     public GameObject KiteSoldier;
//     public GameObject Player;

//     public int Health = 5;
//     private int currentHealth;

//     public int Score;
//     //private int Score = 0;

//     private bool IsGameOver = false;

//     public Level currentLevel;



//     private Vector3 playerPositionNext;
//     private Vector3 playerPositionPrev;
//     private Vector3 playerPositonCurrent;
//     //private Vector3 currentPosition;
//     private float t;

//     public MenuController menuController;

//     public AudioSource level1Music;
//     public AudioSource level2Music;
//     public AudioSource level3Music;
//     public AudioSource playerHit;

//     private int currentLevelHighScore;

//     public CameraController cameraController;
//     public PlayerController playerController;


// 	private void Start()
//     {

//         ////TODO this is here so we don't have to load from the title screen all the time.
//         //GameManager.LoadGameModel();

//         currentHealth = GameModel.Health;
//         HealthSlider.maxValue = currentHealth;
//         HealthSlider.value = currentHealth;
        
//         playerPositionPrev = PlayerPositions.Center;

//         switch(GameModel.CurrentLevel){
//             case 1:
//                 level1Music.Play();
//                 currentLevel = Levels.Level1;
//                 currentLevelHighScore = GameModel.HighScore1;
//                 break;
//             case 2:
//                 level2Music.Play();
//                 currentLevel = Levels.Level2;
//                 currentLevelHighScore = GameModel.HighScore2;
//                 break;
//             case 3:
//                 level3Music.Play();
//                 currentLevel = Levels.Level3;
//                 currentLevelHighScore = GameModel.HighScore3;
//                 break;
//         }

//         TextLevelTitle.text = currentLevel.LevelName;
//         TextHighScore.text = currentLevelHighScore.ToString();
//         TextScore.text = "0";
//         StartCoroutine(TextFade(TextLevelStatus, currentLevel.LevelName));
//         StartCoroutine(PlayLevel());
//     }

//     private void Update()
//     {
// 		//MovePlayer();
//         if(damaged){
//             BloodFade.color = damagedColor;
//         }else{
//             BloodFade.color = Color.Lerp(BloodFade.color, Color.clear, damageFadeTimer*Time.deltaTime);
//         }
//         damaged = false;
//     }

//     bool damaged = false;
//     Color damagedColor = new Color(.5f,0,0,1f);
//     float damageFadeTimer = 2.5f;
// 	public Image BloodFade;

//     public void TakeDamage()
//     {
//         if(!IsGameOver)
//         {
//             damaged = true;
//             cameraController.ShakeCamera(0.1f, .25f);
//             playerHit.Play();
//             currentHealth--;
//             HealthSlider.value = currentHealth;
//             if(currentHealth == 0){
//                 IsGameOver = true;
//                 playerController.Die();
//             }
//         }
//     }

//     public Vector3 currentEnemyExit;

//     IEnumerator TextFade(Text textElement, string text){
//             textElement.text = text;
//             yield return new WaitForSeconds(1.5f);
//             textElement.text = "";
//     }

//     IEnumerator PlayLevel(){


//         while (true)
//         {


//             foreach(Phase phase in currentLevel.Phases)
//             {
//                 youDieYet();

//                 //SetPlayerPosition(phase.PlayerPosition);
//                 ////TODO Animation time hack
//                 yield return new WaitForSeconds(3);

//                 foreach(Wave wave in phase.Waves){
//                     youDieYet();
//                     //// Spawn each wave in turn.

//                     yield return new WaitForSeconds(wave.WavePause);

//                     currentEnemyExit = wave.EnemyExit;
//                     GameObject bagGuy = GetBadGuy(wave.Enemy);

//                     for (int i = 0; i < wave.RepeatCount; i++)
//                     {
//                         youDieYet();

//                         Vector2[] spawnPositions = GetSpawnPositions(wave.EnemySpawn, wave.Formation, wave.ColumnCount, wave.RowCount);
//                         //Vector2[] spawnPositions = GetSpawnPositions(basePosition, wave.Formation, wave.ColumnCount, wave.RowCount);
//                         foreach(Vector2 position in spawnPositions){
//                             GameObject foot = Instantiate(bagGuy, position, transform.rotation);
//                             var footScript = foot.GetComponent<Enemy>();
//                             if(wave.EnemySpawn == EnemySpawns.Left)
//                             {
//                                 footScript.Flip();
//                             }
//                         }                        

//                         yield return new WaitForSeconds(wave.RepeatWait);
//                         youDieYet();
//                     }
//                     yield return new WaitForSeconds(phase.WaitForWave);
//                         youDieYet();
//                 }

//                 ////WaitForNextPhase
//                 yield return new WaitForSeconds(2);
//                 youDieYet();
//             }


//             yield return new WaitForSeconds(4);
//             youDieYet();


//             ////End the Level
//             if (true)
//             {
//                 CheckHighScores();
//                 StartCoroutine(TextFade(TextLevelStatus, "You did it!!!"));
//                 yield return new WaitForSeconds(2);
//                 SetPlayerPosition(PlayerPositions.Center);
//                 yield return new WaitForSeconds(1);
//                 menuController.FadeToMap();

//                 break;
//             }
//         }
// 	}

//     private GameObject GetBadGuy(EnemyType enemyType)
//     {  
//         switch(enemyType){
//             case EnemyType.FootSoldier:
//                 return FootSoldier;
//             case EnemyType.KiteSoldier:
//                 return KiteSoldier;
//             case EnemyType.FastSoldier:
//                 return FastSoldier;
//             default:
//                 return FootSoldier;
//         }

//     }

//     private Vector2[] GetSpawnPositions(Vector2 EnemySpaenZone, FormationType Formation, int ColumnCount, int RowCount){

//             Vector2[] positions;
//             float ySpaceing = .85f;
//             float xSpaceing = .85f;

//             Vector2 basePosition;

//             switch(Formation){
//                 case FormationType.Block:
//                     basePosition = new Vector2(EnemySpaenZone.x, Random.Range(-EnemySpaenZone.y, -1));
//                     positions = new Vector2[(ColumnCount * RowCount)];
//                     int posNum = 0;
//                     for(int r = 0; r < RowCount; r++){
//                         for(int c = 0; c < ColumnCount; c++){
//                             float x = basePosition.x + r * xSpaceing;
//                             float y = basePosition.y - c * ySpaceing;
//                             positions[posNum] = new Vector2(x,y);
//                             posNum++;
//                         }
//                     }                    
//                     return positions;
//                 case FormationType.Wedge:
//                     basePosition = new Vector2(EnemySpaenZone.x, Random.Range(-EnemySpaenZone.y, -1));
//                     positions = new Vector2[6];
//                     ///firstrow
//                     positions[0] = basePosition;
//                     ///second row
//                     positions[1] = new Vector2(basePosition.x+xSpaceing, basePosition.y+ySpaceing/2);
//                     positions[2] = new Vector2(basePosition.x+xSpaceing, basePosition.y-ySpaceing/2);
//                     ///back row
//                     positions[3] = new Vector2(basePosition.x+xSpaceing*2, basePosition.y+ySpaceing);
//                     positions[4] = new Vector2(basePosition.x+xSpaceing*2, basePosition.y);
//                     positions[5] = new Vector2(basePosition.x+xSpaceing*2, basePosition.y-ySpaceing);
//                     return positions;
//                 case FormationType.Stagger:
//                     basePosition = new Vector2(EnemySpaenZone.x, Random.Range(-EnemySpaenZone.y, -1));
//                     positions = new Vector2[ColumnCount];
//                     for(int i = 0; i< ColumnCount; i++){
//                         positions[i] = new Vector2(basePosition.x+i*ColumnCount, basePosition.y);
//                     }
//                     return positions;
//                 case FormationType.RandomStagger:
//                     positions = new Vector2[ColumnCount];
//                     for(int i = 0; i< ColumnCount; i++){
//                         positions[i] = new Vector2(EnemySpaenZone.x + i * 3, Random.Range(-EnemySpaenZone.y, -1));
//                     }
//                     return positions;
//                 default:
//                     positions = new Vector2[1]{new Vector2(EnemySpaenZone.x, Random.Range(-EnemySpaenZone.y, -1))};
//                     return positions;
//             }


//     }

//     void CheckHighScores(){
//         switch(GameModel.CurrentLevel){
//             case 1:
//                 if(Score > GameModel.HighScore1){
//                     GameModel.HighScore1 = Score;
//                 }
//                 break;
//             case 2:
//                 if(Score > GameModel.HighScore2){
//                     GameModel.HighScore2 = Score;
//                 }
//                 break;
//             case 3:
//                 if(Score > GameModel.HighScore3){
//                     GameModel.HighScore3 = Score;
//                 }
//                 break;
//         }
//     }


//     void youDieYet(){
//         if(IsGameOver)
//         {
//             CheckHighScores();
//             StartCoroutine(TextFade(TextLevelStatus, "You died homie."));
//             menuController.FadeToMap();
//         }
//     }


// 	private void MovePlayer()
// 	{
//         if(playerPositionPrev != playerPositionNext)
//         {
//             t += Time.deltaTime/3;
//             Player.transform.position = Vector3.Lerp(playerPositionPrev, playerPositionNext,t);
// 		}
// 	}

// 	public void SetPlayerPosition(Vector3 MoveTo)
// 	{
// 		playerPositionNext = MoveTo;
// 		//Debug.Log(playerPositionPrev + " to " + playerPositionNext);
// 		t=0;
//         playerPositionPrev = Player.transform.position;
// 	}

//     public void AddScore(int ScoreToAdd)
//     {
//         Score += ScoreToAdd;
//         TextScore.text = Score.ToString();
//         if(Score > currentLevelHighScore){
//             TextHighScore.text = Score.ToString();
//         }
//     }

// 	void OnDrawGizmos() {

//         ////Player positions
// 		Gizmos.color = Color.red;
// 		float size = .3f;        
// 		Gizmos.DrawLine(PlayerPositions.Left - Vector2.up * size, PlayerPositions.Left + Vector2.up * size);
// 		Gizmos.DrawLine(PlayerPositions.Left - Vector2.left * size, PlayerPositions.Left + Vector2.left * size);
// 		Gizmos.DrawLine(PlayerPositions.Right - Vector2.up * size, PlayerPositions.Right + Vector2.up * size);
// 		Gizmos.DrawLine(PlayerPositions.Right - Vector2.left * size, PlayerPositions.Right + Vector2.left * size);
// 		Gizmos.DrawLine(PlayerPositions.Center - Vector2.up * size, PlayerPositions.Center + Vector2.up * size);
// 		Gizmos.DrawLine(PlayerPositions.Center - Vector2.left * size, PlayerPositions.Center + Vector2.left * size);

//         ////Enemy Spawns Group
// 		Gizmos.color = Color.red;
//         Vector2 lineStartRight =  new Vector2(EnemySpawns.Right.x, -EnemySpawns.Right.y);
//         Vector2 lineEndRight =  new Vector2(EnemySpawns.Right.x, -1);
// 		Gizmos.DrawLine(lineStartRight, lineEndRight);

//         Vector2 lineStartLeft =  new Vector2(EnemySpawns.Left.x, -EnemySpawns.Left.y);
//         Vector2 lineEndLeft =  new Vector2(EnemySpawns.Left.x, -1);
// 		Gizmos.DrawLine(lineStartLeft, lineEndLeft);

//         ////Enemy Spawns Air
// 		Gizmos.color = Color.blue;
//         Vector2 lineStartRightUp =  new Vector2(EnemySpawns.UpperRight.x, -EnemySpawns.UpperRight.y);
//         Vector2 lineEndRightUp =  new Vector2(EnemySpawns.UpperRight.x, -1);
// 		Gizmos.DrawLine(lineStartRightUp, lineEndRightUp);

//         Vector2 lineStartLeftUp =  new Vector2(EnemySpawns.UpperLeft.x, -EnemySpawns.UpperLeft.y);
//         Vector2 lineEndLeftUp =  new Vector2(EnemySpawns.UpperLeft.x, -1);
// 		Gizmos.DrawLine(lineStartLeftUp, lineEndLeftUp);



// 	}
// }