using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChase : MonoBehaviour
{
    private Rigidbody2D rg2b;
    public float MoveSpeed;
    private Animator Anime;
    public float Range;

    public Transform Player;
    void Start()
    {
        rg2b = GetComponent<Rigidbody2D>();
        Anime = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector2.Distance(transform.position, Player.position);
        if (Distance < Range)
        {
            ChasePlayer();
        }
        else if (Distance > Range)
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

            transform.eulerAngles = new Vector3(0, 0, 0);
            Anime.SetBool("Walk", true);
        }

    }

    private void StopChasingPlayer()
    {
        rg2b.velocity = new Vector2(0, 0);
        Anime.SetBool("Walk", false);
    }
}
