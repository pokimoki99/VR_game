using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
    public DrawWaypoint WayPoint1,WayPoint2;         // An array of transforms for the patrol route.
    int loc;
    bool check = true;
    Vector3 lastpos;



    //public Animator anim;
    public Transform enemybullet;
    bool enemy;
    public GameObject bulletpos;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        Location();
    }
    
    void Update()
    {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        float distance = Vector3.Distance(target.position, this.transform.position);
        if (distance <=lookRadius)
        {
            

            agent.stoppingDistance = 2;

            FaceTarget();
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack the target
                //FaceTarget();
                //agent.SetDestination(target.position);
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Underground_arena"))
            {
                if (distance >=10)
                {
                    Patrolling();
                }


                if (distance >= 1 && distance <10)
                {
                    if (check)
                    {
                        //Location();
                        check = false;
                    }
                    Shooting();
                }
            }
            lastpos = this.gameObject.transform.position;
        }
    }

    public void Patrolling()
    {
        agent.isStopped = false;
        agent.speed = patrolSpeed;
        //Debug.Log(agent.remainingDistance);
        Vector3 curPos = this.gameObject.transform.position;
        //if (agent.velocity == new Vector3(0, 0, 0))
        //{
        //    StartCoroutine(LocationCorotine());

        //    Debug.Log(agent.velocity);
        //}
        //if (curPos==lastpos)
        //{
        //    //StartCoroutine(LocationCorotine());
        //    Location();
        //    //Debug.Log("Check");
        //    check = true;
        //}

        if (Vector3.Distance(agent.destination, this.gameObject.transform.position) < 17.0f)
        {
            Location();

            
        }
    }

    void Shooting()
    {
        //anim.SetBool("Shoot", true);
        agent.speed = 0;
        FaceTarget();
        if (enemy == false)
        {

            //if (anim.GetBool("Shoot") && (!anim.GetBool("IsShooting")))
            //{
            enemy = true;
                //anim.SetBool("IsShooting", true);
                Instantiate(enemybullet, bulletpos.transform.position, transform.rotation);
                StartCoroutine(Rapid());
            Debug.Log("shooting");

            //}
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    void Location()
    {
        if (loc==0)
        {
            agent.SetDestination(WayPoint1.transform.position);
            loc++;
        }
        else
        {
            agent.SetDestination(WayPoint2.transform.position);
            loc--;
        }
    }
    //IEnumerator LocationCorotine()
    //{
    //    //location();
    //    yield return new WaitForSeconds(10);
    //    location();
    //    //Debug.Log("next");
    //}

    IEnumerator Rapid()
    {
        yield return new WaitForSeconds(1.5f);
        enemy = false;
        //anim.SetBool("Shoot", false);
        //anim.SetBool("IsShooting", false);
    }
}
