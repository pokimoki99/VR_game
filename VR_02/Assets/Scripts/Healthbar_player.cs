using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Healthbar_player : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>().OnHealthPctChanged += HandleHealthChanged;
        //GetComponentInParent<Player_Health>().OnHealthPctChanged += HandleHealthChanged;
    }
    private void HandleHealthChanged(float pct)
    {
        StartCoroutine(ChangeToPct(pct));
    }
    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }
        foregroundImage.fillAmount = pct;
    }
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>().OnHealthPctChanged += HandleHealthChanged;
        //transform.Rotate(0, 180);
    }
}
