using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

    private float arrowNext = 0;
    private float arrowPauseNext = 0;

	public int arrowBurstCount = 3;
	public int arrowBurst = 0;

	public ArrowController arrowController;
	public LevelController levelController;
    public float angle = 180;

	public Transform DarkArrowPoint;
    public Transform DarkBowArm;


	public float AttackSpeed = .5f;

	public float AttackPause = 0;

	public int AttackPower = 0;

	public int MaxHealth = 5;
	private int currentHealth;
	
	private GameObject player;

	private Vector3 position;
	private Vector3 nextPosition;

	public bool firing;

	
    public Slider HealthSlider;



	void Start () {

		nextPosition = transform.position;
		player = GameObject.Find("Player");
		arrowController = (ArrowController)GameObject.Find("ArrowController").GetComponent("ArrowController");
		levelController = (LevelController)GameObject.Find("LevelController").GetComponent("LevelController");

		MaxHealth = levelController.WaveNumber;
		HealthSlider.maxValue = MaxHealth;
		currentHealth = MaxHealth;
		HealthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {

		
		Vector3 healthSliderPosition = Camera.main.WorldToScreenPoint(transform.position);
		HealthSlider.transform.position = new Vector3(healthSliderPosition.x, healthSliderPosition.y + 50, healthSliderPosition.z);

		////Ready
		if(!firing){
			if(transform.position.x < EnemySpawns.SkyUpperLeft.x){
				arrowNext = Time.time + Random.Range(.5f, 1.5f);
				firing = true;
			}
		}

		////Aim

		//float targetAngle = 90;

			////Variation

		float targetAngle = AngleBetweenVector2(DarkBowArm.position, player.transform.position) - 20;

 		float turnSpeed =  1f;

		Quaternion nextAngle = Quaternion.Slerp(DarkBowArm.rotation, Quaternion.Euler (0, 0, targetAngle), turnSpeed * Time.deltaTime);
 		DarkBowArm.rotation = nextAngle;


		////Fire 3 burst
		if(firing){
			if(Time.time > arrowPauseNext){
				if (Time.time > arrowNext)
				{
					//angle = angle + 45f;
					arrowController.LooseDarkArrow(DarkArrowPoint.position, nextAngle.eulerAngles.z, AttackPower, false);
					//bowSound.Play();
					arrowNext = Time.time + AttackSpeed;


					arrowBurst++;
					if(arrowBurst == 3){
						arrowPauseNext = Time.time + AttackPause;
						arrowBurst = 0;
					}
					
				}
			}
		}
		////Fire
		// if (firing && Time.time > arrowNext)
		// {
		// 	angle = angle + 45f;
		// 	arrowController.LooseDarkArrow(DarkArrowPoint.position, nextAngle.eulerAngles.z, AttackPower, false);
		// 	//bowSound.Play();
		// 	arrowNext = Time.time + AttackSpeed;
			
		// }


		////Move
		if(transform.position == nextPosition)
		{
			nextPosition = GetNextPosition();
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, nextPosition, .025f);
		}

	}

	public bool IsDead;
	public void TakeDamage(){

		if(!IsDead)
		{
			currentHealth--;
        	HealthSlider.value = currentHealth;
			if(currentHealth < 1)
			{
				IsDead = true;
			}
		}

		if(IsDead)
		{
			levelController.Score(10 + levelController.WaveNumber);
			levelController.EnemyCountTotal--;

			////TODO Poor mans animation
			//dieSound.Play();
			transform.Translate(new Vector2(0, -1) * .5f);
			float dieAngle = (Random.value > 0.5f) ? -90: 90;
				transform.localRotation = Quaternion.Euler(0, 0, dieAngle);

			Destroy(gameObject, .25f);
		}
	}


	 private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
 	{
         Vector2 diference = vec2 - vec1;
         float sign = (vec2.y < vec1.y)? -1.0f : 1.0f;
         return Vector2.Angle(Vector2.right, diference) * sign;
    }

    public Vector3 GetNextPosition(){        

		var x = Random.Range(EnemySpawns.GroundLowerRight.x - 12, EnemySpawns.GroundUpperLeft.x);
		var y = Random.Range(EnemySpawns.GroundLowerRight.y, EnemySpawns.GroundUpperLeft.y);
		return new Vector3(x, y, 0);
	}
	
}