using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Deflect : MonoBehaviour
{

    public Transform bulletprefab;

    Transform deflect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="projectile")
        {
            deflect = other.transform;
            Instantiate(bulletprefab, deflect.position, deflect.rotation);
            Destroy(other);
        }
    }
}
