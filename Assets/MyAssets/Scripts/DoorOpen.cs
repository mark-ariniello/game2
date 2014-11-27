using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour {
	
	private bool open = false;
	private int downtick = 0;
	private Vector3 startPos;
	public float dir = 1.9f;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(open){
			Vector3 hold = startPos;
			hold.x = (hold.x + dir);
			transform.position = Vector3.MoveTowards(transform.position, hold, Time.deltaTime);
		}
		if(!open){
			transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime);
		}
		if(downtick > 0){
		    downtick = downtick-1;
		}
	}

	void Flip (){
		if(downtick == 0){
		    open = !open;
		    Debug.Log ("Detected Door Open/Close Command.");
		    downtick = 3;
		}
	}
}
