using UnityEngine;
using System.Collections;

public class traplight : MonoBehaviour {

	public bool trapTriggered = false;
	public GameObject enemy;
	
	
	void OnTriggerEnter(Collider col){
	    if (col.gameObject.tag == "Player" && !trapTriggered){
		    trapTriggered = true;
			Vector3 en1 = transform.position;
			Vector3 en2 = transform.position;
			Vector3 en3 = transform.position;
			Vector3 en4 = transform.position;
			en1 = en1 + transform.forward*6 + transform.right*6;
			en2 = en2 - transform.forward*6 + transform.right*-6;
			en3 = en3 + transform.forward*6 + transform.right*-6;
			en4 = en4 - transform.forward*6 + transform.right*6;
			Instantiate(enemy, en1, transform.rotation);
			Instantiate(enemy, en2, transform.rotation);
			Instantiate(enemy, en3, transform.rotation);
			Instantiate(enemy, en4, transform.rotation);
			Destroy(gameObject);
		}
	}
}
