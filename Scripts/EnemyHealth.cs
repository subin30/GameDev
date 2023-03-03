using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int CurrentHealth;
    private int MaxHealth = 100;
    public EnemyHealthBar healthBar;

    

    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.maxHealth(MaxHealth);

        
        
    }

    
    

    public void TakeDamage (int Damage)
    {
        CurrentHealth -= Damage;
        AudioScript.PlaySound("EnemyHit");
        healthBar.setHealth(CurrentHealth);
        

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
}
