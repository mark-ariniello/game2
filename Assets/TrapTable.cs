using UnityEngine;
using System.Collections;

public class TrapTable : MonoBehaviour {

	public bool trapTriggered = false;
	public GameObject enemy;
	
	
	void OnTriggerEnter(Collider col){
	    if (col.gameObject.tag == "Player" && !trapTriggered){
		    trapTriggered = true;
			Vector3 en1 = transform.position;
			Vector3 en2 = transform.position;
			en1 = en1 + transform.forward*7 + transform.up*3;
			en2 = en2 - transform.forward*7 + transform.up*3;
			Instantiate(enemy, en1, transform.rotation);
			Instantiate(enemy, en2, transform.rotation);
		}
	}
}
