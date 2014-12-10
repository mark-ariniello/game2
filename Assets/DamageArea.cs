using UnityEngine;
using System.Collections;

public class DamageArea : MonoBehaviour {

	public int tock = 20;
	private int tick = 0;

	void Update(){
		if (tick > 0){
			tick--;
		}
	}

	void OnTriggerStay (Collider col){
		if ((col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") && tick == 0){
			col.gameObject.SendMessage("Damage", 1);
			tick = tock;
		}
	}

}
