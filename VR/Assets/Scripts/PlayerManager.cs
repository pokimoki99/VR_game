using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int PlayerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth <= 0)
        {
            //Gameover menu screen ect.
        }
        else if (PlayerHealth > 0)
        {

        }
    }
    public void DamageProcessor(int damage)
        {
        damage = 10;
        //PlayerHealth=- damage();
        //damage from stuff here espcialy enemies. 
        }
}
