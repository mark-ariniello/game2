using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	public GameObject topDoor;
	public GameObject bottomDoor;
	private bool close;
	private Vector3 a;
	private Vector3 b; 
	private Vector3 c;
	private Vector3 d;

	// Use this for initialization
	void Start () {
		close = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		a = topDoor.transform.localPosition;
		c = bottomDoor.transform.localPosition;
	
		if (a [1] > 0.80746f && close) {
			b [0] = 1f;		
		} 
		else {
			b [0] = 0f;
		}
		if (c [1] < -2.1823f && close) {
			d [0] = 1f;		
		}
		else {
			d [0] = 0f; 
		}
		if ((d [0] == 0f) && (b [0] == 0f) && close) {
			Application.LoadLevel(Application.loadedLevel + 1);	
		}
		//Debug.Log (a);
		//Debug.Log (c);
		topDoor.transform.Translate (b * Time.deltaTime);
		bottomDoor.transform.Translate (d * Time.deltaTime);
	}

	void OnTriggerStay (Collider other){
		close = true;
	}
}
