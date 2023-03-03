using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{
    public GameObject FinishMessage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            FinishMessage.SetActive(true);
            AudioScript.PlaySound("Complete");

        }
        
    }
}
