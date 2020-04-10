using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject theEnemyGunner;
    //public GameObject theEnemySwordsmen;
    int xPos;
    int zPos;
    public int enemyCount;
    public timer tim;
    int enemyRand;
    bool time=true;
    void Update()
    {
        if (enemyCount<=10)
        {
            enemySpawn();
        }
    }
    void enemySpawn()
    {
        if (tim.timerstart <= 200 && tim.timerstart > 0)
        {
            for (enemyCount = 0; enemyCount < 10; enemyCount++)
            {
                if (time==true)
                {
                    xPos = Random.Range(0, 26);
                    zPos = Random.Range(11, 30);
                    Instantiate(theEnemyGunner, new Vector3(xPos, 30, zPos), Quaternion.identity);
                    StartCoroutine(EnemyDrop());
                    time = false;
                }
            }
        }
    }

    IEnumerator EnemyDrop()
    {
      yield return new WaitForSeconds(6.0f);
        time = true;
    }
}

