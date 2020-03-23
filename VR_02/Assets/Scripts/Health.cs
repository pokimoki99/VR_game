﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    private int currentHealth;

    public event Action<float> OnHealthPctChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }
    public void ModifyHealth (int amount)
    {
        currentHealth += amount;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        OnHealthPctChanged(currentHealthPct);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            ModifyHealth(-50);
        }
        if(other.gameObject.tag == "projectile")
        {
            ModifyHealth(-50);
            Debug.Log(currentHealth);
        }
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
