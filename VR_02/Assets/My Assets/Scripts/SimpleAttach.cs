using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SimpleAttach : MonoBehaviour
{
    private Interactable interactable;

    protected bool attached = false;


    [EnumFlags]
    [Tooltip("The flags used to attach this object to the hand.")]
    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    public SteamVR_Action_Boolean GrabPinch;
    public Hand Left_hand;
    public Hand Right_hand;

    public bool shield, sword;

    [Tooltip("The local point which acts as a positional and rotational offset to use while held")]
    public Transform attachmentOffset;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }
    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }
    private void HandHoverUpdate(Hand hand)
    {

        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
            hand.HideGrabHint();

            if (this.gameObject.tag=="Shield")
            {
                shield = true;
            }

            if (this.gameObject.tag=="Sword")
            {
                sword = true;
            }

        }

        
    }

    private void Update()
    {
        GrabPinch.AddOnStateUpListener(Press, inputSource);

    }
    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

            Left_hand.DetachObject(this.gameObject);
            Right_hand.DetachObject(this.gameObject);
    }

}
