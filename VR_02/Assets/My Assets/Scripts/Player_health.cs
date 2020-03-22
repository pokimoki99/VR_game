using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player_health : MonoBehaviour
{

    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
        GetComponent<Health>().OnHealthPctChanged += HandleHealthChanged;
    }

    public void HandleHealthChanged(float pct)
    {
        //StartCoroutine(ChangeToPct(pct));
        material.SetFloat("Cutoff", 0f + pct);
    }
}
