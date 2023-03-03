using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSnail : MonoBehaviour
{
    [SerializeField]
    private Transform startPos, endPos;

    private Rigidbody2D Rg2b;
    private BoxCollider2D box;

    [SerializeField]
    private float speed;

    private Animator Anime;

    bool collison;


    void Awake()
    {
        Rg2b = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        Anime = GetComponent<Animator>();


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
            if (temp.x == 2f)
            {
                temp.x = -2f;


            }
            else
            {
                temp.x = 2f;
            }

            transform.localScale = temp;

        }

    }

    private void Move()
    {
        Rg2b.velocity = new Vector2(transform.localScale.x, 0) * -speed;
        Anime.SetBool("Walk", true);
        

    }
}
