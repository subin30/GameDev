using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;

    public Vector3 offset;

    void Awake()
    {
        

    }

    public void maxHealth(int health)
    {
        
        slider.maxValue = health;
        slider.value = health;
        


    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
