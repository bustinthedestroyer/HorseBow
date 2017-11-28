using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(ShakeTime >= 0){
			Vector2 ShakePosition = Random.insideUnitCircle * shakeAmount;
			transform.position = new Vector3(ShakePosition.x, ShakePosition.y, transform.position.z);
			ShakeTime -= Time.deltaTime;
		}else{
			transform.position = new Vector3(0, 0, transform.position.z);
		}
	}

	float ShakeTime;
	float shakeAmount;

	public void ShakeCamera(float Power, float Duration){
		shakeAmount = Power;
		ShakeTime = Duration;

	}


}
