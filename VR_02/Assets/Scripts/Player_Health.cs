using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }
    public void ModifyHealth(int amount)
    {
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemies_sword")
        {
            ModifyHealth(-10);
        }
        if (other.gameObject.tag == "enemies_projectile")
        {
            ModifyHealth(-5);
            Debug.Log("player" + currentHealth);
        }
        if(currentHealth <= 0)
        {
            Debug.Log("player is dead");
        }
    }
}


