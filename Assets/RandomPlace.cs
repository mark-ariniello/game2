using UnityEngine;
using System.Collections;

public class RandomPlace : MonoBehaviour {
	public GameObject p1;
	public GameObject p2;
	public GameObject p3;
	public GameObject p4;
	public GameObject p5;
	public GameObject p6;
	public GameObject p7;
	public GameObject p8;
	public GameObject p9;
	public GameObject p10;
	public GameObject p11;
	public GameObject p12;
	public GameObject p13;
	public GameObject p14;
	private bool[] flip = new bool[14];
	private Quaternion qi;

	// Use this for initialization
	void Start () {
		// This code is terrifying and horrible.
		qi = Quaternion.identity;

		for (int i = 0; i < 7; i++){
			Vector3 pos = new Vector3(0, 0, 0);
			if (i == 0){
				pos = new Vector3(-40, 0, -40);
			}
			else if (i == 1){
				pos = new Vector3(0, 0, -40);
			}
			else if (i == 2){
				pos = new Vector3(40, 0, -40);
			}
			else if (i == 3){
				pos = new Vector3(-40, 0, 40);
			}
			else if (i == 4){
				pos = new Vector3(0, 0, 40);
			}
			else if (i == 5){
				pos = new Vector3(40, 0, 40);
			}
			else if (i == 6){
				pos = new Vector3(-40, 0, 0);
			}
			else{
				Debug.Log("Error in RandomPlace for loop");
			}
			float hold = Random.Range(1, 15);
			if (hold < 2 && !flip[0]){
				Instantiate(p1, pos, qi);
				flip[0] = true;
			}
			else if (hold >= 2 && hold <3 && !flip[1]){
				Instantiate(p2, pos, qi);
				flip[1] = true;
			}
			else if (hold >= 3 && hold <4 && !flip[2]){
				Instantiate(p3, pos, qi);
				flip[2] = true;
			}
			else if (hold >= 4 && hold <5 && !flip[3]){
				Instantiate(p4, pos, qi);
				flip[3] = true;
			}
			else if (hold >= 5 && hold <6 && !flip[4]){
				Instantiate(p5, pos, qi);
				flip[4] = true;
			}
			else if (hold >= 6 && hold <7 && !flip[5]){
				Instantiate(p6, pos, qi);
				flip[5] = true;
			}
			else if (hold >= 7 && hold <8 && !flip[6]){
				Instantiate(p7, pos, qi);
				flip[6] = true;
			}
			else if (hold >=8 && hold < 9 && !flip[7]){
				Instantiate(p8, pos, qi);
				flip[7] = true;
			}
			else if (hold >= 9 && hold <10 && !flip[8]){
				Instantiate(p9, pos, qi);
				flip[8] = true;
			}
			else if (hold >= 10 && hold < 11 && !flip[9]){
				Instantiate(p10, pos, qi);
				flip[9] = true;
			}
			else if (hold >= 11 && hold < 12 && !flip[10]){
				Instantiate(p11, pos, qi);
				flip[10] = true;
			}
			else if (hold >= 12 && hold < 13 && !flip[11]){
				Instantiate(p12, pos, qi);
				flip[11] = true;
			}
			else if (hold >= 13 && hold < 14 && !flip[12]){
				Instantiate(p13, pos, qi);
				flip[12] = true;
			}
			else if (hold >= 14){
				Instantiate(p14, pos, qi);
				flip[13] = true;
			}
			else{
				i--; // If a chunk has already been placed, don't place it again.
			}

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
