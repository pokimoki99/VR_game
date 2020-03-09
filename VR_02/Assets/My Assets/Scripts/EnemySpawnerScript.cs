using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject theEnemy;
    int xPos;
    int zPos;
    int enemyCount;
    public timer tim;
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
                Instantiate(theEnemy, new Vector3(xPos, 29, zPos), Quaternion.identity);
                yield return new WaitForSeconds(3.0f);
                enemyCount += 1;
            }
        }
    }
}

