using UnityEngine;
using System.Collections;

public class ElevatorProp : MonoBehaviour {
    public GameObject topDoor;
	public GameObject bottomDoor;
	private bool open;
	private Vector3 a;
	private Vector3 b; 
	private Vector3 c;
	private Vector3 d;

	// Use this for initialization
	void Start () {
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		a = topDoor.transform.localPosition;
		c = bottomDoor.transform.localPosition;
	
		if (a [1] < 2.80746f && open) {
			b [0] = -1f;		
		} 
		else {
			b [0] = 0f;
		}
		if (c [1] < -2.1823f && open) {
			d [0] = -1f;		
		}
		else {
			d [0] = 0f; 
		}
		//Debug.Log (a);
		//Debug.Log (c);
		topDoor.transform.Translate (b * Time.deltaTime);
		bottomDoor.transform.Translate (d * Time.deltaTime);
	}
	
	void OnTriggerStay (Collider n){
	    open = true;
	}
}
