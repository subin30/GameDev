using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    [SerializeField]
    private Transform startPos, endPos;

    private Rigidbody2D Rg2b;
    private CircleCollider2D Circle;

    [SerializeField]
    private float speed;

    bool collison;


    void Awake()
    {
        Rg2b = GetComponent<Rigidbody2D>();
        Circle = GetComponent<CircleCollider2D>();

    }


    void FixedUpdate()
    {
        Move();
        changeDirection();
        
        

    }

    private void changeDirection()
    {
        collison = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        if (!collison)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 1f)
            {
                temp.x = -1f;


            }else
            {
                temp.x = 1f;
            }

            transform.localScale = temp;

        }
        
    }

    private void Move()
    {
        Rg2b.velocity = new Vector2(transform.localScale.x, 0) * -speed;

    }

   
}
