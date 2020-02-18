using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class Moving_object : MonoBehaviour
{
    public bool selected;
    public SteamVR_LaserPointer laserPointer;


    [EnumFlags]
    [Tooltip("The flags used to attach this object to the hand.")]
    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

    [Tooltip("The local point which acts as a positional and rotational offset to use while held")]
    public Transform attachmentOffset;

    public bool attach;
    public Hand hand;
    public HandEvent onHeldUpdate;
    public SteamVR_Action_Boolean GrabPinch;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller

    void Start()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        selected = false;

        GrabPinch.AddOnStateUpListener(UnPress, inputSource);
    }
    public void PointerInside(object sender, PointerEventArgs e)
    {
        OnHandHoverBegin(hand);
        if (e.target.name == this.gameObject.name && selected == false)
        {
            selected = true;
            Debug.Log("pointer is inside this object" + e.target.name);
            GrabPinch.AddOnStateDownListener(Press, inputSource);

        }
    }
    public void PointerOutside(object sender, PointerEventArgs e)
    {

        if (e.target.name == this.gameObject.name && selected == true)
        {
            selected = false;
            Debug.Log("pointer is outside this object" + e.target.name);

        }
    }
    public bool get_selected_value()
    {
        return selected;
    }

    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }

    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }


    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        if (selected)
        {
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
        }

    }

    private void UnPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        selected = false;
        hand.DetachObject(gameObject);
    }

}
