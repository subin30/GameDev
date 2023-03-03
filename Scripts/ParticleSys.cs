using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSys: MonoBehaviour
{
    public GameObject Dust;

    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Instantiate(Dust, transform.position, transform.rotation);
        }
    }
}
