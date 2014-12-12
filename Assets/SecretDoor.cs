using UnityEngine;
using System.Collections;

public class SecretDoor : MonoBehaviour {

private bool open = false;
	private int downtick = 0;
	private Vector3 startPos;
	public float dir = 5f;
	// Use this for initialization
	void Start () {
		startPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(open){
			Vector3 hold = startPos;
			hold.y = (hold.y + dir);
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, hold, Time.deltaTime);
		}
		if(!open){
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, Time.deltaTime);
		}
		if(downtick > 0){
			downtick = downtick-1;
		}
	}
	
	void Flip (){
		if(downtick == 0){
			open = true;
			Debug.Log ("Detected Secret Door Open.");
			downtick = 3;
		}
	}
}