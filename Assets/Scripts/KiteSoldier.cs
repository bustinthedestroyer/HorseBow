using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiteSoldier : Enemy {

	public GameObject Bomb;
    private float bombNext = 0;
	public float bombNextMin;
	public float bombNextMax;

	bool droppingBombs = false;
	void Update ()
	{
		if(!droppingBombs){
			if(transform.position.x < EnemySpawns.SkyUpperLeft.x){
				bombNext = Time.time + Random.Range(bombNextMin, bombNextMax);
				droppingBombs = true;
			}
		}

		if(droppingBombs){
			if (Time.time > bombNext)
			{
				bombNext = Time.time + Random.Range(bombNextMin, bombNextMax);
				Instantiate(Bomb, transform.position, transform.rotation);
			}
		}
	}
}
