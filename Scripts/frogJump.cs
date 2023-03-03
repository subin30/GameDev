using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogJump : MonoBehaviour
{
    
    public float force =200f;

    private Animator anime;
    private Rigidbody2D rg2b;
    


    void Awake()
    {
        anime = GetComponent<Animator>();
        rg2b = GetComponent<Rigidbody2D>();
        
    }
    private void Start()
    {
        StartCoroutine(Attack());
    }


    IEnumerator Attack()
    {
        
        yield return new WaitForSeconds(Random.Range(2, 5));
        force = Random.Range(50f, 80f);

        rg2b.velocity = new Vector2(rg2b.velocity.x, force);
        //anime.SetBool("Jump", true);

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Attack());


    }

    
}
