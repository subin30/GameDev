using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rg2b;

    [SerializeField]
    private float BulletSpeed;

    public float LifeTime;

    public GameObject Particle;

    public GameObject HitEnemyParticle;

    
    
    void Awake()
    {
        rg2b = GetComponent<Rigidbody2D>();
        Invoke("Destroy", LifeTime);

        
    }

    
    void FixedUpdate()
    {
        rg2b.velocity = transform.right * BulletSpeed;
        
      }

    private void Destroy()
    {
        Instantiate(Particle, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Destroy();
        }
    }

    
}
