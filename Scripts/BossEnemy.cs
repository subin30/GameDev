using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed;

    private Animator Anime;

    private Rigidbody2D rg2b;

    private BoxCollider2D box;

    public Transform Player;

    public float range;

    public GameObject Bullet;

    [SerializeField]
    private Transform BulletPoint;

    public float StartTime;
    private float TimeBetweenAttack;

    

    void Awake()
    {

        Anime = GetComponent<Animator>();
        rg2b = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, Player.position);
       

        if (distanceToPlayer < range)
        {
            ChasePlayer();
            

            if (TimeBetweenAttack <= 0)
            {
               GameObject light = Instantiate(Bullet, BulletPoint.position, BulletPoint.rotation);

                StartTime = UnityEngine.Random.Range(1, 5);
               
                TimeBetweenAttack = StartTime;
            }
            else
            {
                TimeBetweenAttack -= Time.deltaTime;
            }


        }
        else
        {
            StopChasingPlayer();
        }

        
    }

    

    private void ChasePlayer()
    {
        if (transform.position.x < Player.position.x)
        {
            rg2b.velocity = new Vector2(MoveSpeed, rg2b.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0);
            
            Anime.SetBool("Walk", true);


           
        }




        else 
        {
            rg2b.velocity = new Vector2(-MoveSpeed, rg2b.velocity.y);
            
            transform.eulerAngles = new Vector3(0,0,0);
            BulletPoint.eulerAngles = new Vector3(0, 180, 0);
            Anime.SetBool("Walk", true);
            
        }
       
    }

    private void StopChasingPlayer()
    {
        rg2b.velocity = new Vector2(0, 0);
        Anime.SetBool("Walk", false);
    }
}
