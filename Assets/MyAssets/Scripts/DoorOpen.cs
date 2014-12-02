using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {

	private bool open;
	public GameObject door;
	private Vector3 a;
	private Vector3 b;

	// Use this for initialization
	void Start () {
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
		b = door.transform.localPosition;
		if (b [0] <= -2f && !open) {
			a [0] = 0f;
			open = true;
			Debug.Log("door is open");
		}
		if (b [0] >= 0f && open) {
			a [0] = 0f;
			open = false;
			Debug.Log("door is closed");
		}
		Debug.Log(open);
		door.transform.Translate(a * Time.deltaTime);
	}

	void OnTriggerStay (Collider other) {
		Debug.Log ("entered the trigger area");
		if (!open && Input.GetKeyUp ("e")) {
			//Debug.Log("made activated the door");
			a [0] = -1f;
		}
		if (open && Input.GetKeyUp ("e")) {
			Debug.Log("closed the door");
			a [0] = 1f;
		}
	}
}
