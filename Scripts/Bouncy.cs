using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float Force =90f;
    private Animator anime;
    void Start()
    {
        anime = GetComponent<Animator>();

        
    }

   IEnumerator Bounce()
    {
        anime.Play("Spring");
        yield return new WaitForSeconds(0.5f);
        anime.Play("SpringDown"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            collision.gameObject.GetComponent<PlayerController>().BouncePlayer(Force);
            StartCoroutine(Bounce());
        }
    }

    void Update()
    {
        
    }
}
