using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript_sniper : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * +500);
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }

}
