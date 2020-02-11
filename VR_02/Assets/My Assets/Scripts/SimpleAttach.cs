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
        //GrabTypes grabType = hand.GetGrabStarting();
        //bool isGrabEnding = hand.IsGrabEnding(gameObject);

        //if ((interactable.attachedToHand = null) && (grabType != GrabTypes.None))
        //{
        //    hand.AttachObject(gameObject, grabType);
        //    hand.HoverLock(interactable);
        //    hand.HideGrabHint();
        //}

        //else if (isGrabEnding)
        //{
        //    hand.DetachObject(gameObject);
        //    hand.HoverUnlock(interactable);
        //}

        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags, attachmentOffset);
            hand.HideGrabHint();
        }
    }
}
