using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;


public class Button : MonoBehaviour
{
    private Interactable interactable;

    [EnumFlags]
    [Tooltip("The flags used to attach this object to the hand.")]
    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    public SteamVR_Action_Boolean GrabPinch;
    public Hand hand;

    bool selection;
    bool once=true;
    public timer cooldown;
    public Transform target;
    public GameObject del;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
        selection = true;

    }
    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
        selection = false;
    }

    // Update is called once per frame
    void Update()
    {
        GrabPinch.AddOnStateUpListener(Press, inputSource);
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (selection)
        {
            Debug.Log("is selected");

                //gameObject.transform.Translate(0, -0.01f*Time.deltaTime, 0);

                gameObject.transform.position=Vector3.MoveTowards(transform.position,target.position,Time.deltaTime);
            Destroy(del);
            text.GetComponent<Text>().enabled = false;

            if (once)
            {
            cooldown.timerstart = 300;
            cooldown.cdt();
                once = false;
            }


        }
        
    }
}
