using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    private static int time;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        time = timer.timerstart;
        if (time <= 200)
        {
            while (enemyCount < 10)
            {
                xPos = Random.Range(0, 26);
                zPos = Random.Range(11, 30);
                Instantiate(theEnemy, new Vector3(xPos, 29, zPos), Quaternion.identity);
                yield return new WaitForSeconds(1.0f);
                enemyCount += 1;
            }
        }
    }
}

