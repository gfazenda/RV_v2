using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour {
    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;


    public LayerMask grabMask;

    GameObject grabbedObject;
    bool grabbing = false;
    public float grabRadius;

    // Use this for initialization
    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Grab()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);
        if (hits.Length > 0)
        {
            int closestHit = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.tag=="Bone" && hits[i].distance < hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }
            grabbing = true;
            grabbedObject = hits[closestHit].transform.gameObject;
            grabbedObject.GetComponent<Bone>().setGrabbed(this.gameObject);
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            grabbedObject.transform.position = transform.position;
            grabbedObject.transform.parent = transform;
        }


    }

    void DropObject()
    {
        grabbing = false;
        if (grabbedObject != null)
        {
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Bone>().setDropped();
            grabbedObject.GetComponent<Bone>().TeleportBack();
            grabbedObject.transform.parent = null;

            grabbedObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }
        
        if (!grabbing && /*controller.GetPressDown(gripButton) ||*/ controller.GetPressDown(triggerButton))
        {
            Debug.Log("trigger1");
            Grab();
        }
        else if (grabbing && /*controller.GetPressDown(gripButton) ||*/ controller.GetPressDown(triggerButton))
        {
            Debug.Log("trigger2");
            DropObject();
        }


    }
	
	// Update is called once per frame
	//void Update () {
       // transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
      //  transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
   // }
}
