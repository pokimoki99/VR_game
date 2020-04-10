using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_hp : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float healthRegenAmount;

    public GameObject healthBarUI;
    public Slider slider;

    public int death;
   

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
            health += healthRegenAmount * Time.deltaTime;

        }
        if (health <= 0)
        {
            SceneManager.LoadScene("Character_Selection");
            death++;
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        //}



    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Enemy_Bullet")
        {
            health = health - 20;
        }
    }
}
