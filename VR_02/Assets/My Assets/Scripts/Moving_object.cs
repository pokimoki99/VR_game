using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class Moving_object : MonoBehaviour
{
    public bool selected;
    public SteamVR_LaserPointer Left_laserPointer;


    [EnumFlags]
    [Tooltip("The flags used to attach this object to the hand.")]
    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

    [Tooltip("The local point which acts as a positional and rotational offset to use while held")]
    public Transform attachmentOffset;

    public bool attach;
    public Hand Lefthand;
    public HandEvent onHeldUpdate;
    public SteamVR_Action_Boolean GrabGrip;
    public SteamVR_Input_Sources Left_inputSource = SteamVR_Input_Sources.LeftHand;//which controller

    float distance=0;
    Vector3 Previous_Position;

    Health Enemy_Health;

    GrabTypes Left_startingGrabType;

    void Start()
    {
        Left_laserPointer.PointerIn += PointerInside;
        Left_laserPointer.PointerOut += PointerOutside;

        selected = false;
        Previous_Position = new Vector3(0,0,0);
        GrabGrip.AddOnStateUpListener(UnPress, Left_inputSource);

    }
    public void PointerInside(object sender, PointerEventArgs e)
    {
        OnHandHoverBegin(Lefthand);
        if (e.target.name == this.gameObject.name && selected == false)
        {
            selected = true;
            if (Left_inputSource == SteamVR_Input_Sources.LeftHand)
            {
                GrabGrip.AddOnStateDownListener(Press, Left_inputSource);
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
        Left_startingGrabType = Lefthand.GetGrabStarting();
        Previous_Position = new Vector3(0, 0, 0);
        if (selected)
        {
            if (Left_inputSource == SteamVR_Input_Sources.LeftHand)
            {
                Lefthand.AttachObject(gameObject, Left_startingGrabType, attachmentFlags, attachmentOffset);
                Previous_Position = this.gameObject.transform.position;
                Left_startingGrabType = Lefthand.GetGrabEnding();
            }

        }

    }

    private void UnPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        selected = false;
        if (Left_startingGrabType == Lefthand.GetGrabEnding())
        {
            Lefthand.DetachObject(gameObject);
            Debug.Log("left hand detach");
        }
        distance += Vector3.Distance(this.gameObject.transform.position, Previous_Position);
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy_Health = FindClosestEnemy().GetComponent<Health>();
            Enemy_Health.ModifyHealth((int)distance);
        }

    }
}
