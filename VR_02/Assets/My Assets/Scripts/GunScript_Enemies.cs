using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GunScript_Enemies : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;

    public Transform bulletprefab;
    // Use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float dotProd = Vector3.Dot(transform.forward,(target.position - transform.position).normalized);

        while (dotProd > 0.9)
        {

            Instantiate(bulletprefab, gameObject.transform.position, gameObject.transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
