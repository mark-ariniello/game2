using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {
    private bool picked = false;
	void Pickup () {
	    if (!picked){
		    picked = true;
	        GameObject hold = GameObject.Find("TheDude");
	        hold.SendMessage("ammoGet", 10);
		    Destroy(gameObject);
		}
	}
}
