using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class Dragging_object : MonoBehaviour
{
    public bool selected;
    public SteamVR_LaserPointer Right_laserPointer;


    [EnumFlags]
    [Tooltip("The flags used to attach this object to the hand.")]
    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

    [Tooltip("The local point which acts as a positional and rotational offset to use while held")]
    public Transform attachmentOffset;

    public bool attach;
    public Hand Righthand;
    public HandEvent onHeldUpdate;
    public SteamVR_Action_Boolean GrabGrip;
    public SteamVR_Input_Sources Right_inputSource = SteamVR_Input_Sources.RightHand;//which controller

    float distance = 0;
    Vector3 Previous_Position;

    Health Enemy_Health;
    
    GrabTypes Right_startingGrabType;

    void Start()
    {

        Right_laserPointer.PointerIn += PointerInside;
        Right_laserPointer.PointerOut += PointerOutside;

        selected = false;
        Previous_Position = new Vector3(0, 0, 0);

    }
    public void PointerInside(object sender, PointerEventArgs e)
    {
        OnHandHoverBegin(Righthand);
        if (e.target.name == this.gameObject.name && selected == false)
        {
            selected = true;
            if (Right_inputSource == SteamVR_Input_Sources.RightHand)
            {
                GrabGrip.AddOnStateDownListener(Press, Right_inputSource);
            }
        }
    }
    public void PointerOutside(object sender, PointerEventArgs e)
    {

        if (e.target.name == this.gameObject.name && selected == true)
        {
            selected = false;

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
        Right_startingGrabType = Righthand.GetGrabStarting();
        Previous_Position = new Vector3(0, 0, 0);
        if (selected)
        {
            if (Right_inputSource == SteamVR_Input_Sources.RightHand)
            {
                //this.gameObject.transform.position = Righthand.transform.position + new Vector3(0,0,0);
                this.gameObject.transform.position = Righthand.transform.position + transform.forward;
                Righthand.AttachObject(gameObject, Right_startingGrabType, attachmentFlags, attachmentOffset);
            }

        }

    }

    private void UnPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        selected = false;
        Righthand.DetachObject(gameObject);
    }
}
