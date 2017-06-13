using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	private float speed = 2000f;
	public GameObject camera;
	public GameObject Hand, Description;
	int DownLimit = 50, UpLimit = -30;
	GameObject Bone,GameManager;
	float yRotation = 0f, xRotation = 0f;
	public bool hasObj = false;
    public LayerMask grabMask;

    GameObject grabbedObject;
    public float grabRadius;
    void Start () {
		GameManager = GameObject.Find ("GameManager");
	}

	void FixedUpdate () {
		//if (!GameManager.GetComponent<GameManagerScript> ().PauseTimer) {
			if (hasObj) //move bone with player
                grabbedObject.transform.position = Hand.transform.position;

			//rotation
			float mouseHorizontal = Input.GetAxis ("Mouse X");
			float mouseVertical = Input.GetAxis ("Mouse Y");
			yRotation += mouseHorizontal;
			xRotation += mouseVertical * -1;
			transform.eulerAngles = new Vector3 (0, yRotation, 0);

			if (xRotation <= DownLimit && xRotation >= UpLimit) {
				camera.transform.eulerAngles = new Vector3 (xRotation, yRotation, 0);
			} else {
				if (xRotation > DownLimit)
					xRotation = DownLimit;
				if (xRotation < UpLimit)
					xRotation = UpLimit;
			}

			//movement
			float moveVertical = Input.GetAxis ("Vertical");
			float moveHorizontal = Input.GetAxis ("Horizontal");
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			GetComponent<Rigidbody> ().velocity = Vector3.zero;

			GetComponent<Rigidbody> ().AddRelativeForce (movement * speed);
		//}
	}

	void Update(){
		if (Input.GetMouseButtonDown(0)) {
            if (hasObj)
            {

                DropObject();
            }else
            {
                Grab();
            }
			//ChangeBoneRigidBody (true);
			//hasObj = false;
			//GameManager.GetComponent<GameManagerScript>().DisablePanel();
		}
	}

	public void ChangeBoneRigidBody(bool Active = false){
		Bone.GetComponent<Rigidbody> ().useGravity = Active;
		Bone.GetComponent<Rigidbody> ().detectCollisions = Active;
	}

	public void getObject(GameObject bone){
        if (!hasObj)
        {
            hasObj = true;
          //  GameManager.GetComponent<GameManagerScript>().BoneDescription(bone);
            Bone = bone;
            ChangeBoneRigidBody();
        }
	}


    void Grab()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 10f, grabMask);
        
        if (hits.Length > 0)
        {
            Debug.Log(hits.Length);
            int closestHit = -1;
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].collider.gameObject.tag);
                if (hits[i].collider.gameObject.tag == Tags.Bone)
                {
                    if (closestHit != -1 && hits[i].distance < hits[closestHit].distance)
                    {
                        closestHit = i;
                    }else
                    {
                        closestHit = i;
                    }
                }
            }
            if (closestHit != -1)
            {
                Description.SetActive(true);
                hasObj = true;
                grabbedObject = hits[closestHit].transform.gameObject;
                grabbedObject.GetComponent<Bone>().setGrabbed(this.gameObject);
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                grabbedObject.transform.position = Hand.transform.position;
                grabbedObject.transform.parent = transform;
            }
        }


    }

    void DropObject()
    {
        hasObj = false;
        Description.SetActive(false);
        if (grabbedObject != null)
        {
           
            grabbedObject.GetComponent<Bone>().setDropped();
            //grabbedObject.GetComponent<Bone>().TeleportBack();
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
        }
    }
}
