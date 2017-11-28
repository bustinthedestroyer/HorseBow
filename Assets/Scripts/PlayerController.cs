using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private bool moving = false;
	private bool aiming = false;

	public float speed;

	public CircleCollider2D movingCollider;
    public ArrowController ArrowController;
    private float angle;
    public Transform BowArm;
    public Transform FireHalo;
    private float arrowNext = 0;
    public AudioSource bowSound;

	public bool firing = false;

	void Start()
	{
		movingCollider = GetComponent<CircleCollider2D>();
		angle = 20;
	}

	void Update () {
		
        ////Are we touching the screen and not already moving?
        if (Input.GetButtonDown("Fire1") && !moving)
        {
			////Get touch position.
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			////Are we touching the horse, then move?
			////Otherwise we are aiming the bow.
			if(movingCollider.OverlapPoint(touchPosition))
			{
            	moving = true;
			}else{
            	aiming = true;
			}

        }

		////If we are moving?
        if(moving)
        {
            ////Move toware the touch position.
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			////Make sure we are not flying :(
			float horseY = transform.position.y;
			if(horseY > 0){
				touchPosition = new Vector2(transform.position.x, 0);
			}

         	transform.position = Vector2.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime);
		}

		////If we are aiming?
		if(aiming){
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var y = ArrowController.ArrowPoint.position.y - touchPosition.y;
			var x = ArrowController.ArrowPoint.position.x - touchPosition.x;
			angle = (Mathf.Atan2(-y, -x) * Mathf.Rad2Deg);
			BowArm.rotation = Quaternion.Euler(new Vector3(0,0,angle));
			FireHalo.rotation = Quaternion.Euler(new Vector3(0,0,angle));
		}

		////Alway shoot the bow
		if(firing){
			if (Time.time > arrowNext)
			{
				arrowNext = ArrowController.FireArrow(angle);
				bowSound.Play();
				
			}
		}


		////Reset controls then the finger is up.
        if (Input.GetButtonUp("Fire1"))
        {
            moving = false;
			aiming = false;
        }
	}

	public void Die(){
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        	transform.position = new Vector2(transform.position.x, transform.position.y -2);
			firing = false;
	}
}