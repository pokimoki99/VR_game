using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss_Health : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    public Transform bulletprefab;

    public GameObject bossring, bossring1, bossring2, bossring3, bossring4, bossring5, bossring6, bossring7;
    bool rage=true;
    bool damage=true;


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
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Win");
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if (health <= (maxHealth/2))
        {
            if (rage==true)
            {
                StartCoroutine(Bossrage());
                rage = false;
            }
            //boss rage mode

        }
    }
    float CalculateHealth()
    {
        return health / maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sword")
        {
            if (damage == true)
            {
                health -= 50;
                damage = false;
                StartCoroutine(boss_damage_cooldown());
            }

        }
        if (other.gameObject.tag == "projectile")
        {
            health -= 50;
        }

    }

    IEnumerator Bossrage()
    {
        Instantiate(bulletprefab, bossring.transform.position, bossring.transform.rotation);
        Instantiate(bulletprefab, bossring1.transform.position, bossring1.transform.rotation);
        Instantiate(bulletprefab, bossring2.transform.position, bossring2.transform.rotation);
        Instantiate(bulletprefab, bossring3.transform.position, bossring3.transform.rotation);
        Instantiate(bulletprefab, bossring4.transform.position, bossring4.transform.rotation);
        Instantiate(bulletprefab, bossring5.transform.position, bossring5.transform.rotation);
        Instantiate(bulletprefab, bossring6.transform.position, bossring6.transform.rotation);
        Instantiate(bulletprefab, bossring7.transform.position, bossring7.transform.rotation);
        yield return new WaitForSeconds(2.8f);
        rage = true;
    }
    IEnumerator boss_damage_cooldown()
    {
        yield return new WaitForSeconds(1.0f);
        damage = true;

    }
}
