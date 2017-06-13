using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Body : MonoBehaviour {
    public List<GameObject> missingBones = new List<GameObject>();
    public TextMesh feedback;
    [HideInInspector]
    public List<string> boneNames = new List<string>();
    public int ID;
    string currentBone;
    void Start()
    {
        setupList();
    }

    void setupList()
    {
        for (int i = 0; i < missingBones.Count; i++)
        {
            boneNames.Add(missingBones[i].name);
        }
        GameManager.Instance.setList(ID, boneNames);
    }

    void showText(bool right = true, float duration = 1.2f)
    {
       /* Vector3 look = */feedback.gameObject.transform.LookAt(GameManager.Instance._player.transform.position);
       // Vector3 currPos = feedback.gameObject.transform.position;
        // currPos
        if (right)
        {
            feedback.text = "Right";
            feedback.color = Color.green;
        }
        else
        {
            feedback.text = "Wrong";
            feedback.color = Color.red;
        }
        feedback.gameObject.SetActive(true);
        Invoke("disableText", duration);
    }

    private void Update()
    {
        // feedback.gameObject.transform.LookAt(GameManager.Instance._player.transform.position);
        if (feedback.gameObject.activeInHierarchy)
        {
            Vector3 targetDir = transform.position - GameManager.Instance._player.transform.position;
            feedback.gameObject.transform.rotation = Quaternion.LookRotation(targetDir);
        }
    }

    void disableText()
    {
        feedback.gameObject.SetActive(false);
    }

    bool CheckBone(GameObject bone)
    {
        currentBone = "";
        bool isRight = false;
        Debug.Log("step 4");
        Debug.Log(bone.name);
        for (int i = 0; i < boneNames.Count; i++)
        {
            if (bone.name == boneNames[i])
            {
                currentBone = bone.name;
                boneNames.Remove(boneNames[i]);
                bone.SetActive(false);
                bone.transform.position = new Vector3(1000,1000,1000);
                Debug.Log("got it");
                isRight = true;
            }
        }
        return isRight;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == Tags.Bone)
        {
            Debug.Log("step1");
            if (!other.GetComponent<Bone>().isGrabbed && CheckBone(other.gameObject))
            {
                Debug.Log("step2");
                GameManager.Instance.updateVictims(ID, currentBone);
                showText();
            }else
            {
                Debug.Log("step3");
                showText(false);
                other.GetComponent<Bone>().TeleportBack();
            }
        }
    }

    //public string victimName, Killer;
    //public Text boneList;
    //public List<string> Missing_Bones;
    //public List<string> Collected_Bones;
    //public TextMesh v_name1, v_name2;
    //GameObject Player, GameManager;
    //public bool isComplete = false;

    //void Start () {
    //	Player = GameObject.Find ("Player");
    //	GameManager = GameObject.Find ("GameManager");
    //	v_name1.text = victimName;
    //	v_name2.text = victimName;
    //	UpdateBoneList ();
    //}


    //void UpdateBoneList(){
    //	boneList.text = "";
    //	boneList.alignment = TextAnchor.MiddleLeft;
    //	for (int i =0; i< Collected_Bones.Count; i++) {
    //		boneList.text += "<color=#00ff00ff> - " + Collected_Bones [i] + "</color>" + '\n';			
    //	}
    //	for (int i =0; i< Missing_Bones.Count; i++) {
    //		boneList.text += " - " + Missing_Bones [i] + '\n';			
    //	}
    //}

    //public List<string> getBones(){
    //	return Missing_Bones;
    //}

    //bool CheckBone(GameObject bone){
    //	bool isRight = false;
    //	for (int i =0; i< Missing_Bones.Count; i++) {
    //		if (bone.name == Missing_Bones [i] && !Player.GetComponent<PlayerScript> ().hasObj) {
    //			Collected_Bones.Add(Missing_Bones[i]);
    //			Missing_Bones.Remove (Missing_Bones [i]);
    //			bone.GetComponent<BoneScript> ().isCollected = true;
    //			Destroy(bone);
    //			isComplete = (Missing_Bones.Count == 0);
    //			UpdateBoneList();
    //			isRight = true;
    //		}
    //	}
    //	return isRight;
    //}

    //void OnTriggerStay(Collider other){
    //	if (other.gameObject.tag == "Bone") {
    //		bool RightTable = CheckBone(other.gameObject);
    //		if (!RightTable && !Player.GetComponent<PlayerScript> ().hasObj){
    //			GameManager.GetComponent<GameManager>().FeedbackMessage(RightTable);
    //			other.GetComponent<BoneScript> ().TeleportBack ();
    //		}
    //		else if(RightTable)
    //			GameManager.GetComponent<GameManager>().FeedbackMessage(RightTable);
    //	}
    //}
}
