using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
        
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
}
