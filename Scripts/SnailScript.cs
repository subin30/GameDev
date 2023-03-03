using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D Rg2b;
    private CircleCollider2D Circle;

    [SerializeField]
    private float speed;

    
    void Awake()
    {
        Rg2b = GetComponent<Rigidbody2D>();
        Circle = GetComponent<CircleCollider2D>();
        
    }

    
    void FixedUpdate()
    {
        Rg2b.velocity = new Vector2(speed, Rg2b.velocity.y);
        
    }
}
