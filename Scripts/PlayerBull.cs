using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBull : MonoBehaviour
{
    private Rigidbody2D rg2b;

    [SerializeField]
    private float BulletSpeed;

    public float LifeTime;

    public GameObject Particle;
    private int damage = 40;



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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            
            Instantiate(Particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if (collision.tag == "ImmuneEnemy")
        {
            AudioScript.PlaySound("Error");
            Instantiate(Particle, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
