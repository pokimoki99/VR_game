using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Selection_choice : MonoBehaviour
{

    public SimpleAttach weapon_type;
    public GameObject shield, sword;
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (weapon_type.shield==true)
        {
            Instantiate(shield, player.transform.position, player.transform.rotation);
        }
        if (weapon_type.sword==true)
        {
            Instantiate(sword, player.transform.position, player.transform.rotation);
        }
    }
}
