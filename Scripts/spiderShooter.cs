using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    void Start()
    {
        StartCoroutine(Attack());
        
    }

    
   IEnumerator Attack()
    {
        yield return new WaitForSeconds (Random.Range(1, 3));

        Instantiate(bullet, transform.position, Quaternion.identity);

        StartCoroutine(Attack());

    }

    
}
