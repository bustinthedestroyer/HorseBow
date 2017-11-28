using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Entities;

public class Enemy : MonoBehaviour {

	public int Speed;
    private bool isFlipped;
    public bool Go;

    public AudioSource dieSound;

    public bool IsDead = false;

    public LayerMask Targets;

    public bool Flying = false;

    public LevelController levelController;

    void Start(){
        levelController =  GameObject.Find("LevelController").GetComponent<LevelController>();
        Go=true;
    }

    void FixedUpdate()
    {
        if(Go){
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * Speed);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.1f, Targets);
            if(hit.collider != null){
                DoDamage();
            }
        }  
    }

    public void TakeDamage()
    {
       levelController.Score(1);

        IsDead = true;
        Speed = 0;
        ////TODO Poor mans animation
        transform.Translate(new Vector2(0, -1) * .5f);
        float dieAngle = (Random.value > 0.5f) ? -90: 90;
        if(isFlipped)
        {
            transform.localRotation = Quaternion.Euler(0, 0, dieAngle);
        }else{
            transform.localRotation = Quaternion.Euler(0, 0, dieAngle);
        }
        dieSound.Play();
        Destroy(gameObject, .25f);
    }

    public void DoDamage()
    {
        levelController.TakeDamage();
        Destroy(gameObject);
    }

    public void Flip(){
        isFlipped = true;
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    void OnDestroy() {
        levelController.EnemyCountTotal--;
    }
}