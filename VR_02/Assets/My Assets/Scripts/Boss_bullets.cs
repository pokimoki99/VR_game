using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_bullets : MonoBehaviour
{
    int rand;
    // Use this for initialization
    void Start()
    {

            GetComponent<Rigidbody>().AddForce(transform.right * 500);

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
