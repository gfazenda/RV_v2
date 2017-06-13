using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControllers : MonoBehaviour {
    //OVRInput.Controller controller;
    public LayerMask grabMask;

    GameObject grabbedObject;
    bool grabbing = false;
    public float grabRadius;
	// Use this for initialization
	void Start () {
		
	}

    void Grab()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius,transform.forward,0f,grabMask);
        if(hits.Length > 0)
        {
            int closestHit = 0;
            for (int i = 0; i < hits.Length; i++)
            {
                if(hits[i].distance < hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }
            grabbing = true;
            grabbedObject = hits[closestHit].transform.gameObject;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            grabbedObject.transform.position = transform.position;
            grabbedObject.transform.parent = transform;
        }


    }

    void DropObject()
    {
        grabbing = false;
        if(grabbedObject != null)
        {
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            

            grabbedObject.transform.parent = null;

            grabbedObject = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
       //// if (!grabbing && Input.GetKeyDown(KeyCode.Joystick1Button0))
       //if(!grabbing && OVRInput.GetDown(OVRInput.Button.One))
       // {
       //     Debug.Log("grabbing");
       //     Grab();
       // }
       // if (grabbing && OVRInput.GetDown(OVRInput.Button.Two))
       // {
       //     Debug.Log("release");
       //     //Grab();
       // }

        //Vector3 testX, testZ;
        //testX = Input.GetAxis("Horizontal");
        //testZ = Input.GetAxis("Vertical");

        //Vector3 translate = (testX + testZ) * _velocidade * Time.deltaTime;
        //translate.y = 0;

        //transform.position += translate;
        //OVRInput.GetLocalControllerPosition(controller);
        //OVRInput.GetLocalControllerRotation(controller);
    }
}
