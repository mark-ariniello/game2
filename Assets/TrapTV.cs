using UnityEngine;
using System.Collections;

public class TrapTV : MonoBehaviour {
    private bool trapTriggered = false;
	
	void OnTriggerEnter(Collider col){
	    if (col.gameObject.tag == "Player" && trapTriggered == false){
		    trapTriggered = true;
			float hold = Random.Range(1, 8);
			Vector3 place;
			if (hold <= 2){
			    place = new Vector3 (-40f, 3.1f, -40f);
			}
			else if (hold > 2 && hold <= 3){
			    place = new Vector3 (0f, 3.1f, -40f);
			}
			else if (hold > 3 && hold <= 4){
			    place = new Vector3 (40f, 3.1f, -40f);
			}
			else if (hold > 4 && hold <= 5){
			    place = new Vector3 (-40f, 3.1f, 40f);
			}
			else if (hold > 5 && hold <= 6){
			    place = new Vector3 (0f, 3.1f, 40f);
			}
			else if (hold > 6 && hold <= 7){
			    place = new Vector3 (40f, 3.1f, 40f);
			}
			else{
			    place = new Vector3 (-40f, 3.1f, 0f);
			}
			col.gameObject.transform.position = place;
		}
	}
}
