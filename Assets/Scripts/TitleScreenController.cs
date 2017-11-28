using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

public class TitleScreenController : MonoBehaviour {

	public ArrowController arrowController;
	public Transform ArrowSpawnMin;
	public Transform ArrowSpawnMax;
	public GameObject Arrow;

	public float ArrowSpawnAngle = -90;
	public float ArrowSpawnSpeed;

	public float ArrowPower;

    private float ArrowNext = 0;

	void Update(){
		if(Time.time > ArrowNext){
			SpawnArrow();
			ArrowNext = Time.time + ArrowSpawnSpeed;
		}
	}
	void SpawnArrow(){

		Vector3 ArrowPosition = new Vector3(Random.Range(ArrowSpawnMin.position.x, ArrowSpawnMax.position.x), ArrowSpawnMin.position.y, ArrowSpawnMin.position.z);
		arrowController.LooseArrow(ArrowPosition, ArrowSpawnAngle + Random.Range(-10,10), 850);
	}

	private void Start(){

		////Do this to reset all saved bits.
		//PlayerPrefs.DeleteAll();


		PlayerModel.Load();
	}
}