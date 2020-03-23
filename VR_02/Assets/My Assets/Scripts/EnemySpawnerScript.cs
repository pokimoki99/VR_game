using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject theEnemyGunner;
    public GameObject theEnemySwordsmen;
    int xPos;
    int zPos;
    int enemyCount;
    public timer tim;
    int enemyRand;
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        if (tim.timerstart<=200 && tim.timerstart>=0)
        {
            while (enemyCount < 10)
            {
                xPos = Random.Range(0, 26);
                zPos = Random.Range(11, 30);
                enemyRand = Random.Range(1, 2);
                if(enemyRand == 1)
                {
                    Instantiate(theEnemyGunner, new Vector3(xPos, 29, zPos), Quaternion.identity);

                }
                else if (enemyRand == 2)
                {
                    Instantiate(theEnemySwordsmen, new Vector3(xPos, 29, zPos), Quaternion.identity);

                }
                yield return new WaitForSeconds(3.0f);
                enemyCount += 1;
            }
        }
    }
}

