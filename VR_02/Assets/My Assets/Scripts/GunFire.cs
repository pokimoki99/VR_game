using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;


public class GunFire : MonoBehaviour
{
    public Transform bulletprefab;
    public SteamVR_Action_Boolean GrabGrip;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    public GameObject firepoint;
    public SimpleAttach gun_equipped;

    // Start is called before the first frame update
    void Start()
    {
        GrabGrip.AddOnStateUpListener(UnPress, inputSource);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
            GrabGrip.AddOnStateDownListener(Press, inputSource);
        
    }
    private void OnDisable()
    {
        GrabGrip.AddOnStateUpListener(UnPress, inputSource);
    }
    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (gun_equipped.gun_attached == true)
        {
            Instantiate(bulletprefab, firepoint.transform.position, gameObject.transform.rotation);
        }
    }

    private void UnPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }

}
