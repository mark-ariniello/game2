using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	void NewGame(){
		Application.LoadLevel("lvl1");
	}
	void LoadGame(){
		int hold = PlayerPrefs.GetInt("Level", 1);
		if (hold == 1){
			Application.LoadLevel("lvl1");
		}
		else if (hold == 2){
			Application.LoadLevel("lvl2");
		}
		else if (hold == 3){
			Application.LoadLevel("lvl3");
		}
	}
	void Quit(){
		Application.Quit ();
	}
}
