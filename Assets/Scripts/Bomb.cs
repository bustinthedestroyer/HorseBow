using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public LayerMask Targets;
	// Use this for initialization
	void Start () {
		
        var rb = GetComponent<Rigidbody2D>();
		rb.angularVelocity = 100;
	}
	
	// Update is called once per frame
	void Update () {
		
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.1f, Targets);
		if (hit.collider != null)
        {			
            GameObject.Find("LevelController").GetComponent<LevelController>().TakeDamage();
			Destroy(gameObject);
		}
	}
}
