using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;

    public Transform Pos1, Pos2;
    public Transform StartPos;

    Vector3 NextPos;
    void Start()
    {
        NextPos = StartPos.position;
        
    }

    
    void Update()
    {
        if (transform.position == Pos1.position)
        {
            NextPos = Pos2.position;
        }
        if (transform.position == Pos2.position)
        {
            NextPos = Pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, NextPos, speed * Time.deltaTime);
        
    }
}
