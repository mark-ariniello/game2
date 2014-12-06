using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject topDoor;
	public GameObject bottomDoor;
	private bool close;
	private Vector3 a;
	private Vector3 b; 
	private Vector3 c;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider other){
		a = topDoor.transform.localPosition;
		b = bottomDoor.transform.localPosition;
		if (b[1] >= -2f) {
	}
}
