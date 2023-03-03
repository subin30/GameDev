using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerShake : MonoBehaviour
{
    private Animator Anime;

    private void Awake()
    {
        Anime = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Anime.SetTrigger("Move");
        }

    }

}
