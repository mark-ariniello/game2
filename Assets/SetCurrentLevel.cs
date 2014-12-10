using UnityEngine;
using System.Collections;

public class SetCurrentLevel : MonoBehaviour {

	public int levelnum = 1;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Level", levelnum);
	}
}
