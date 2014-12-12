using UnityEngine;
using System.Collections;

public class batteryPickup : MonoBehaviour {

	void Pickup () {
	    GameObject hold = GameObject.Find("TheDude");
	    hold.SendMessage("batteryGet");
		Destroy(gameObject);
	}
}
