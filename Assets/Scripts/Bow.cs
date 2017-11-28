using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {


//     public GUIText TextPower;

//     private bool drawing = false;
//     private Vector3 drawStart;
//     public ArrowController arrowController;
    
//     public LineRenderer lineRenderer;

//     public float DrawDistanceMinimum;
//     private float powerNext;
//     private int powerCurrent = 0;
//     private float arrowNext = 0;

//     private Color fadeWhite;
//     private Color fadeRed;

//     public AudioSource bowSound;

//     public Transform BowArm;

//     public int SelectedWeapon;

//     void Start(){
//         fadeWhite = new Color(Color.white.r, Color.white.g, Color.white.b, 0.5f);
//         fadeRed = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
//         TextPower.color = fadeWhite;
//         TextPower.text = "";
//         SelectedWeapon = GameModel.SelectedWeapon;
//     }


//     void Update()
//     {
//         ////Drawing the bow
//         //Draw();

//         ////Shoot the bow
//         //Shoot();
//     }

//     private float angle;

//     void Shoot(){

//         ////Are we touch the screen
//         if (Input.GetButtonDown("Fire1") && !drawing)
//         {
//             drawing = true;
//         }

//         if(drawing)
//         {
//             ////Find angle from arrow potin to screen position
//             var currentposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             var y = arrowController.ArrowPoint.position.y - currentposition.y;
//             var x = arrowController.ArrowPoint.position.x - currentposition.x;
//             angle = (Mathf.Atan2(-y, -x) * Mathf.Rad2Deg);

//             if (Time.time > arrowNext)
//             {
//                 arrowNext = Time.time + GameModel.FireRate;
//                 bowSound.Play();
//                 arrowController.SpecialAttack(SelectedWeapon, angle);
//             }
            
//             BowArm.rotation = Quaternion.Euler(new Vector3(0,0,angle));

//             ////Release the aroow on finger up, and stop drawing.
//             if (Input.GetButtonUp("Fire1") && drawing)
//             {
//                 drawing = false;
//                 BowArm.rotation = Quaternion.Euler(new Vector3(0,0,-145));
//             }
//         }

//     }
//     void Draw(){


//         ////Knock and arrow and draw the bow on finger down.
//         if (Input.GetButtonDown("Fire1") && !drawing)
//         {
//             drawStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             ////Move the power text next to the draw start
//             drawing = true;
//         }

//         if(drawing){
//             ////Contstanly update the angle while drawing
//             var currentEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//             var y = currentEnd.y - drawStart.y;
//             var x = currentEnd.x - drawStart.x;
//             angle = (Mathf.Atan2(y, x) * Mathf.Rad2Deg);
//             //angle = (Mathf.Atan2(-y, -x) * Mathf.Rad2Deg);

//             ////Draw the angle on the sceen from the start to the current end.
//             lineRenderer.SetPosition(0, new Vector3(drawStart.x, drawStart.y, 0));
//             lineRenderer.SetPosition(1, new Vector3(currentEnd.x, currentEnd.y, 0));
            
//             ////Shoot arrow if we have draw far enough, change angle indicato colors.
//             if(Vector3.Distance(drawStart, currentEnd) > DrawDistanceMinimum){
//                 if (Time.time > arrowNext)
//                 {
//                     arrowNext = Time.time + GameModel.FireRate;
//                     bowSound.Play();
//                     arrowController.SpecialAttack(SelectedWeapon, angle);
//                 }
//             }
//             ////Gain Power if we have not reached the max and we have not excedded the next power time.
//             if (Time.time > powerNext && powerCurrent < GameModel.PowerMax)
//             {
//                 powerNext = Time.time + GameModel.PowerRate;
//                 powerCurrent++;
//                 TextPower.text = powerCurrent.ToString();
//             }

//             ////Turn indicators red when you can power attack
//             if(powerCurrent == GameModel.PowerMax)
//             {
//                 TextPower.color = Color.red;
//                 lineRenderer.startColor = fadeRed;
//                 lineRenderer.endColor = fadeRed;
//             }

//             ////Rotate Arm to kind of look like shooting
//             BowArm.rotation = Quaternion.Euler(new Vector3(0,0,angle));


//             ////Release the aroow on finger up, and stop drawing.
//             if (Input.GetButtonUp("Fire1") && drawing)
//             {
//                 // if(powerCurrent == GameModel.PowerMax)
//                 // {
//                 //     arrowController.SpecialAttack(4, angle);
//                 // }
//                 ////Clean up and reset drawing and arrow properties
//                 drawing = false;
//                 lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
//                 lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
//                 lineRenderer.startColor = fadeWhite;
//                 lineRenderer.endColor = fadeWhite;
//                 powerCurrent = 0;
//                 TextPower.text = "";
//                 TextPower.color = fadeWhite;
//                 BowArm.rotation = Quaternion.Euler(new Vector3(0,0,-145));
//             }

//             ////Move the power text next to the draw start
//             ////TODO you should only have to do this on draw start I would think, but it acts weird when we do that, so update it if drawing
//             TextPower.transform.position = Camera.main.WorldToViewportPoint(new Vector2(drawStart.x + .5f, drawStart.y + .5f));             
//         }

//     }
// 	void OnDrawGizmos() {
// 		Gizmos.color = Color.cyan;
// 		float size = .3f;
// 		Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(-transform.position.y, 0), transform.position.z);
// 		Gizmos.DrawLine(spawnPosition - Vector3.up * size, spawnPosition + Vector3.up * size);
// 		Gizmos.DrawLine(spawnPosition - Vector3.left * size, spawnPosition + Vector3.left * size);
// 	}
}

//     ////Old Draw
    
//     //void Draw(){
//     //     ////Knock and arrow and draw the bow on finger down.
//     //     if (Input.GetButtonDown("Fire1") && !drawing)
//     //     {
//     //         drawStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//     //         ////Move the power text next to the draw start
//     //         drawing = true;
//     //     }

//     //     if(drawing){
//     //         ////Contstanly update the angle while drawing
//     //         var currentEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//     //         var y = currentEnd.y - drawStart.y;
//     //         var x = currentEnd.x - drawStart.x;
//     //         angle = (Mathf.Atan2(y, x) * Mathf.Rad2Deg);
//     //         //angle = (Mathf.Atan2(-y, -x) * Mathf.Rad2Deg);

//     //         ////Draw the angle on the sceen from the start to the current end.
//     //         lineRenderer.SetPosition(0, new Vector3(drawStart.x, drawStart.y, 0));
//     //         lineRenderer.SetPosition(1, new Vector3(currentEnd.x, currentEnd.y, 0));
            
//     //         ////Shoot arrow if we have draw far enough, change angle indicato colors.
//     //         if(Vector3.Distance(drawStart, currentEnd) > DrawDistanceMinimum){
//     //             if (Time.time > arrowNext)
//     //             {
//     //                 arrowNext = Time.time + GameModel.FireRate;
//     //                 bowSound.Play();
//     //                 arrowController.SpecialAttack(SelectedWeapon, angle);
//     //             }
//     //         }
//     //         ////Gain Power if we have not reached the max and we have not excedded the next power time.
//     //         if (Time.time > powerNext && powerCurrent < GameModel.PowerMax)
//     //         {
//     //             powerNext = Time.time + GameModel.PowerRate;
//     //             powerCurrent++;
//     //             TextPower.text = powerCurrent.ToString();
//     //         }

//     //         ////Turn indicators red when you can power attack
//     //         if(powerCurrent == GameModel.PowerMax)
//     //         {
//     //             TextPower.color = Color.red;
//     //             lineRenderer.startColor = fadeRed;
//     //             lineRenderer.endColor = fadeRed;
//     //         }

//     //         ////Rotate Arm to kind of look like shooting
//     //         BowArm.rotation = Quaternion.Euler(new Vector3(0,0,angle));


//     //         ////Release the aroow on finger up, and stop drawing.
//     //         if (Input.GetButtonUp("Fire1") && drawing)
//     //         {
//     //             // if(powerCurrent == GameModel.PowerMax)
//     //             // {
//     //             //     arrowController.SpecialAttack(4, angle);
//     //             // }
//     //             ////Clean up and reset drawing and arrow properties
//     //             drawing = false;
//     //             lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
//     //             lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
//     //             lineRenderer.startColor = fadeWhite;
//     //             lineRenderer.endColor = fadeWhite;
//     //             powerCurrent = 0;
//     //             TextPower.text = "";
//     //             TextPower.color = fadeWhite;
//     //             BowArm.rotation = Quaternion.Euler(new Vector3(0,0,-145));
//     //         }

//     //         ////Move the power text next to the draw start
//     //         ////TODO you should only have to do this on draw start I would think, but it acts weird when we do that, so update it if drawing
//     //         TextPower.transform.position = Camera.main.WorldToViewportPoint(new Vector2(drawStart.x + .5f, drawStart.y + .5f));             
//     //     }

//     // }

//     ////Older Draw
//     // void Draw(){

//     //     ////Knock and arrow and draw the bow on finger down.
//     //     if (Input.GetButtonDown("Fire1") && !drawing)
//     //     {
//     //         if(knockedArrow == null)
//     //         {
//     //             knockedArrow = Instantiate(Arrow, new Vector3(transform.position.x,transform.position.y,transform.position.z+1), transform.rotation);
//     //         }
//     //         drawStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//     //         drawing = true;
//     //     }

//     //     ////Release the aroow on finger up, and stop drawing.
//     //     // if (Input.GetButtonUp("Fire1") && drawing)
//     //     // {
//     //     //     LooseArrow();
//     //     //     drawing = false;
//     //     // }
//     //     if (Time.time > ArrowNext)
//     //     {
//     //         ArrowNext = Time.time + FireRate;
//     //         arrowController.LooseArrow(transform.position, transform.rotation, 15);
//     //     }



//     //     if(drawing){
//     //         ////Draw the angle on the sceen from the start to the current end.
//     //         var currentEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//     //         lineRenderer.SetPosition(0, new Vector3(drawStart.x, drawStart.y, 0));
//     //         lineRenderer.SetPosition(1, new Vector3(currentEnd.x, currentEnd.y, 0));
            
//     //         ////Change the angle indicator colors when the bow is bent far enough.
//     //         if(Vector3.Distance(drawStart, currentEnd) > DrawDistanceMinimum){
//     //             lineRenderer.startColor = Color.red;
//     //             lineRenderer.endColor = Color.red;
//     //         }else{
//     //             lineRenderer.startColor = Color.white;
//     //             lineRenderer.endColor = Color.white;
//     //         }

//     //         ////If an arrow is knocked, rotate it to make draw angle.
//     //         if(knockedArrow != null)
//     //         {
//     //             var y = currentEnd.y - drawStart.y;
//     //             var x = currentEnd.x - drawStart.x;
//     //             float rotation = (Mathf.Atan2(-y, -x) * Mathf.Rad2Deg);
//     //             knockedArrow.transform.eulerAngles = new Vector3(0,0,rotation);                
//     //         }

//     //         ////Move the power text next to the draw start
//     //         TextPower.transform.position = Camera.main.WorldToViewportPoint(new Vector2(drawStart.x + .5f, drawStart.y + .5f));
//     //         ////Gain Power if we have not reached the max and we have not excedded the next power time.
//     //         if (Time.time > powerNext && powerCurrent < PowerMax)
//     //         {
//     //             powerNext = Time.time + PowerGain;
//     //             powerCurrent++;
//     //             TextPower.text = powerCurrent.ToString();            
//     //             knockedArrow.GetComponent<Arrow>().Piercing = true;
//     //         }
//     //     }
//     // }

//     // void LooseArrow()
//     // {

//     //     Arrow arrow = knockedArrow.GetComponent<Arrow>();

//     //     ////Link power to arrow speed
//     //     //int calcedPower = 20 + powerCurrent > PowerMin ? powerCurrent : PowerMin;        
//     //     arrow.Power = 15;
        
//     //     ////Clean up and reset drawing and arrow properties
//     //     knockedArrow = null;
//     //     lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
//     //     lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
//     //     lineRenderer.startColor = Color.white;
//     //     lineRenderer.endColor = Color.white;
//     //     powerCurrent = 0;
//     //     TextPower.text = "";
//     // }
