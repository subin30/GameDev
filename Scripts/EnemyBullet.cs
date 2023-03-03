using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D Rg2b;
    public float Speed;
    public GameObject DustParticles;
    
    public float lifeTime;
    private PlayerController player;
   
    void Start()
    {
        Rg2b = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();


        
    }

    // Update is called once per frame
    void Update()
    {
        Rg2b.velocity = transform.right * Speed;
        Invoke("Destroy", lifeTime);
        
        
    }
    private void Destroy()
    {
        Instantiate(DustParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(DustParticles, transform.position, Quaternion.identity);
            player.Damage(30);
        }
        
    }
}
