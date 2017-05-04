using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy {
    public float maxHealth, power, toughness, currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void PerformAttack(int amount)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Destroy(this.gameObject);
    }
}
