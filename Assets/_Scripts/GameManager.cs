using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Body Table1, Table2, Table3;
    public Victim Victim1, Victim2, Victim3;
    public Text Timer;
    public GameObject _player;
    public int currentTime = 300;
    int min = 0, sec = 0;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    // Use this for initialization
    void Start () {
        //Victim1.setupList(Table1.boneNames);
        //Victim2.setupList(Table2.boneNames);
        //Victim3.setupList(Table3.boneNames);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndGame(bool won = false)
    {
        if (won)
        {
          //  this.GetComponent<ClipboardScript>().DisablePanels();
          //  GameOverText.text = "You Won! Congratulations!";
          //  GameOverText.color = Color.green;
        }
      //  GameOverText.gameObject.SetActive(true);
      //  menu_script.GameOverMenu();
        Time.timeScale = 0f;
    }

    public void Countdown()
    {
        //if (!PauseTimer)
        //    currentTime -= 1;

        if (currentTime <= 0)
        {
            currentTime = 0;
            EndGame();
        }

        min = currentTime / 60;

        if (min > 12)
        {
            min -= (12 * (min / 12));
        }

        sec = currentTime % 60;
        Timer.text = string.Format("{0:D2}:{1:D2}", min, sec);
    }

    public void setList(int ID, List<string> names)
    {
        switch (ID)
        {
            case 1:
                {
                    Victim1.setupList(names);
                }
                break;
            case 2:
                {
                    Victim2.setupList(names);
                }
                break;
            case 3:
                {
                    Victim3.setupList(names);
                }
                break;
        }
    }


    public void updateVictims(int ID, string BoneName)
    {
        switch (ID)
        {
            case 1:
                {
                    Victim1.UpdateList(BoneName);
                }
                break;
            case 2:
                {
                    Victim2.UpdateList(BoneName);
                }
                break;
            case 3:
                {
                    Victim3.UpdateList(BoneName);
                }
                break;
        }
    }
}
