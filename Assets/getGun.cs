using UnityEngine;
using System.Collections;

public class getGun : MonoBehaviour {

	void Pickup () {
	    GameObject hold = GameObject.Find("TheDude");
	    hold.SendMessage("gunGet");
		Destroy(gameObject);
	}
}
