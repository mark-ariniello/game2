using UnityEngine;
using System.Collections;

public class ShovelGet : MonoBehaviour {

	// Use this for initialization
	void shovelGet(){
		GameObject hold = GameObject.Find("TheDude");
		hold.SendMessage("shovelGet");
		Destroy(gameObject);
	}
}
