using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GunScript_Enemies : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;

    public float shotTime = 5.0f;

    public Transform bulletprefab;
    // Use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is clled once per frame
    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float dotProd = Vector3.Dot(transform.forward, (target.position - transform.position).normalized);
        shotTime -= Time.deltaTime;
        if(dotProd >= -1)
        {
            shotTime -= Time.deltaTime;

            if (shotTime <= 0.0f)
            {
                Instantiate(bulletprefab, gameObject.transform.position, gameObject.transform.rotation);
                shotTime = 5.0f;
            }
        }
    }
}
