using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CustomEditor(typeof(UIController))]
public class UIController : MonoBehaviour {
    public List<Image> buttons;
    public bool autoPopulate = true, horizontal = true, configureAtRuntime = true;
    [Tooltip("Values in screen % (1 to 100)")]
    public float sizeX, offset, sizeY;


    [Tooltip("1st button position")]
    public Vector2 startPosition;
	// Use this for initialization
	void Start () {
        if (autoPopulate)
        {
            buttons.AddRange(this.GetComponentsInChildren<Image>());
        }

        if(configureAtRuntime)
            configureUI();
    }
	
   public void configureUI()
    {
        sizeX *= 0.01f; //% to 1/100
        offset *= 0.01f; //% to 1/100
        sizeY *= 0.01f;//% to 1/100

        if (horizontal)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                float x = startPosition.x + (sizeX * i) + (i > 0 ? (offset * i) : 0);
                buttons[i].GetComponent<RectTransform>().anchorMin = new Vector2((float)(x), startPosition.y);
                buttons[i].GetComponent<RectTransform>().anchorMax = new Vector2((float)(x + sizeX), (float)startPosition.y + sizeY);
            }
        }
        else
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                float y = startPosition.y + (sizeY * i) + (i > 0 ? (offset * i) : 0);
                buttons[i].GetComponent<RectTransform>().anchorMin = new Vector2(startPosition.x, (float)y);
                buttons[i].GetComponent<RectTransform>().anchorMax = new Vector2((float)startPosition.x + sizeX, (float)(y + sizeY));
            }
        }
    }
}
