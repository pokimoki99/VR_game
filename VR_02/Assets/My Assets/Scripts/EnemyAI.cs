using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform enemybullet;
    public GameObject bulletpos;
    GameObject player;
    bool enemy;
    NavMeshAgent anim;

    private void Start()
    {
        gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        FaceTarget();
        if (enemy == false)
        {

                Instantiate(enemybullet, bulletpos.transform.position, transform.rotation);
                StartCoroutine(Rapid());
           
        }
    }

    IEnumerator Rapid()
    {
        enemy = true;
        yield return new WaitForSeconds(1.5f);
        enemy = false;
    }
    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }
}
