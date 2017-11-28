using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

public class Arrow : MonoBehaviour {

    public float TimeToLive;
    public float Power;
    public LayerMask Targets;
    public bool DestroyOnImpact;
    public bool Held = true;
    public bool Piercing = false;
    public int PiercingMax = 5;
    private int piercingCurrent = 0;

    private Rigidbody2D rb;

    private bool go=true;

    public float Force;

    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();

        ////Destroy if there is a time to live
        if(TimeToLive != 0)
        {
            GameObject.Destroy(gameObject, TimeToLive);
        }
    }

    void FixedUpdate()
    {
        if(go){
            rb.AddForce(transform.right * PlayerModel.Power);
            go=false;
        }else
        {
            Fly();
        }
    }

    void Fly()
    {
        ////Rotate arrow to fall in an arch;
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));

        ////Ray cast to see if we hit anything
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 0.1f, Targets);
        if (hit.collider != null)
        {

            ////To Hit a player
            var player = hit.collider.GetComponent<PlayerController>();
            if (player != null)
            {
                GameObject.Find("LevelController").GetComponent<LevelController>().TakeDamage();
            }

            ////To Hit a Boss
            var boss = hit.collider.GetComponent<BossController>();
            if (boss != null)
            {
                if(!boss.IsDead){
                    boss.TakeDamage();
                }
            }

            // ////Destroy Stop or pierce 
            // if (Piercing && piercingCurrent < PiercingMax){
            //     piercingCurrent++;
            // }else if(DestroyOnImpact){
            //     Destroy(gameObject);
            // }else{
            //     Held = true;
            // }

            ////Do damage to it if it's a badguy
            var targetHealth = hit.collider.GetComponent<Enemy>();
            if (targetHealth != null)
            {
                if(!targetHealth.IsDead){
                    targetHealth.TakeDamage();
                }
            }

            ////Pierce
            if (Piercing){
            //if (Piercing && piercingCurrent < PiercingMax){
                piercingCurrent++;
            }else{
                Destroy(gameObject);
            }

            ////TODO Arrows that stick.


        }
    }
}
