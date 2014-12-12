using UnityEngine;
using System.Collections;

public class HealthKitPickup : MonoBehaviour {
	
	void Pickup () {
	    GameObject hold = GameObject.Find("TheDude");
	    hold.SendMessage("Heal", 6);
		Destroy(gameObject);
	}
}
