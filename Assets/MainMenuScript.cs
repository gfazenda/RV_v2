using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public void PlayGame(){
		Application.LoadLevel ("MainScene");
	}

	public void Tutorial(){
		Application.LoadLevel ("Tutorial");
	}

	public void Quit(){
		Application.Quit ();
	}




}
