using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victim : MonoBehaviour {
    [HideInInspector]
    public List<string> missingBones = new List<string>();
    public List<string> collectedBones = new List<string>();
    public string victimName;
    public Text _name, boneList;
	// Use this for initialization
	void Start () {
        _name.text = victimName;
    }

   public void setupList(List<string> bones)
    {
        for (int i = 0; i < bones.Count; i++)
        {
            missingBones.Add(bones[i]);
            //boneList.text += "- " + missingBones[i].name;
        }
        setupText();
    }

    void setupText()
    {
        if (missingBones.Count == 0)
        {
            _name.text = "<color=#00ff00ff>" + victimName + "</color>";
        }
            boneList.text = "";
        boneList.alignment = TextAnchor.MiddleLeft;
        for (int i = 0; i < collectedBones.Count; i++)
        {
            boneList.text += "<color=#00ff00ff> - " + collectedBones[i] + "</color>" + '\n';
        }
        for (int i = 0; i < missingBones.Count; i++)
        {
            boneList.text += " - " + missingBones[i] + '\n';
        }
    }

    public void UpdateList(string bone)
    {
        if (missingBones.Count == 0)
            return; 

        for (int i = 0; i < missingBones.Count; i++)
        {
            Debug.Log(missingBones[i]);
            Debug.Log("s " + bone);
           if(missingBones[i] == bone)
            {
                Debug.Log("collected");
                collectedBones.Add(bone);
                missingBones.RemoveAt(i);
                setupText();
                return;
            }
        }
    }

}
