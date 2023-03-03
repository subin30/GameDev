using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{

    private PlayerController Player;

    void Awake()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        if (gameObject.name == "MoveLeft")
        {
            Player.MoveLeft(true);

        }
        else
        {
            Player.MoveLeft(false);

        }


    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Player.StopMoving();

    }


}
