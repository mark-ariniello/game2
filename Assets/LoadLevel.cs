using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	void LoadLevels(){
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

	void ReturnMenu(){
		Application.LoadLevel ("MainMenu");
	}
}
