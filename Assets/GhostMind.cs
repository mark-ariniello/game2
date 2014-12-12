using UnityEngine;
using System.Collections;

public class GhostMind : MonoBehaviour {

    private int state = 0;
	private GameObject player;
	public float speed = 10f;
	public int health = 4;
	private float step;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		step = speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.transform.position, transform.position) <= 12f  && state != 1){
			state = 1;
			Debug.Log ("State 1 Entered.");
		}
		if(Vector3.Distance(player.transform.position, transform.position) > 12f && state == 1){
			state = 0;
		}
		if(health == 0){
			Destroy(gameObject);
		}
		if(Vector3.Distance(player.transform.position, transform.position) < 1f){
		  player.SendMessage("Damage", 1);
		}
	}

	void FixedUpdate(){
		if(state == 1){
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
		}
	}

	void Damage(int dam){
		health = health-dam;
		Debug.Log ("Enemy took damage: " + dam);
	}
}
