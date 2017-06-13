using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bone: MonoBehaviour {
	Canvas canvas;
    GameObject player;
	public bool isGrabbed = false;
	Vector3 OriginalPosition;
	string description;
    public bool show = false;
	void Start () {
		OriginalPosition = this.transform.position;
        canvas = this.GetComponentInChildren<Canvas>();
        canvas.enabled = false;

    }

    private void Update()
    {
        if (isGrabbed)
        {
            Vector3 pos = player.transform.position;
            pos.z -= 15;
            // canvas.transform.position = pos;
            canvas.transform.LookAt(-pos);
        }
    }

    //public string getDescription(){
    //	description = this.GetComponent<Text> ().text;
    //	return description;
    //}

    public void setGrabbed(GameObject player)
    {
        this.player = player;
        isGrabbed = true;
       // canvas.enabled = true;
    }

    public void setDropped()
    {
        this.player = null;
        isGrabbed = false;
        //canvas.enabled = false;
    }

    public void TeleportBack(){
		this.transform.position = OriginalPosition;
	}
}
