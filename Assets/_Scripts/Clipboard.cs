using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClipboardScript : MonoBehaviour {

	//public List<GameObject> Victims;
	//public Text clipBoard;
	//GameObject SuspectPanel;
	//public List<InputField> Suspects;
	//public List<GameObject> Tables;
	//public Button sendInfo;
	//bool isShowingVictims = false, isShowingSuspects = false, canSend;

	//void Start () {
	//	NameVictims ();
	//	SuspectPanel = GameObject.Find ("SuspectPanel");
	//	SuspectPanel.SetActive (false);
	//}


	//void NameVictims(){
	//	for (int i =0; i<Victims.Count; i++) {
	//		Victims [i].text = Tables [i].GetComponent<BodyScript> ().victimName;
	//	}
	//}

	//public void ShowClipBoard(){
	//	CheckSendButton ();
	//	isShowingVictims = !isShowingVictims;
	//	clipBoard.gameObject.SetActive(isShowingVictims);
	//	this.gameObject.GetComponent<GameManagerScript> ().PauseTimer = isShowingVictims;
	//}

	//public void DisablePanels(){
	//	SuspectPanel.SetActive(false);
	//	clipBoard.gameObject.SetActive(false);
	//}

	//public void ShowSuspects(){
	//	isShowingSuspects = !isShowingSuspects;
	//	SuspectPanel.SetActive(isShowingSuspects);
	//	this.gameObject.GetComponent<GameManagerScript> ().PauseTimer = isShowingSuspects;
	//}

	//public void CheckSendButton(){
	//	canSend = true;
	//	for (int i=0; i<Tables.Count; i++) {
	//		if(!Tables[i].GetComponent<BodyScript> ().isComplete)
	//			canSend = false;
	//	}
	//	sendInfo.gameObject.SetActive (canSend);
	//}

	//public void SendInfo(){
	//	bool WonGame = true;
	//	for (int i =0; i<Victims.Count; i++) {
	//		if (Tables [i].GetComponent<BodyScript> ().Killer != Suspects [i].text)
	//			WonGame = false;
	//	}
	//	if (WonGame)
	//		this.gameObject.GetComponent<GameManagerScript> ().EndGame (true);
	//	else {
	//		this.gameObject.GetComponent<GameManagerScript>().currentTime -= 30;
	//		this.gameObject.GetComponent<GameManagerScript>().Countdown();
	//	}
	//}
}
