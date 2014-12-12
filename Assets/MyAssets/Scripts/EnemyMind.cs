using UnityEngine;
using System.Collections;

public class EnemyMind : MonoBehaviour {

	private int state = 0;
	private GameObject player;
	public float speed = 10f;
	public int health = 8;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(player.transform.position, transform.position) <= 30f  && state != 1){
			state = 1;
			Debug.Log ("State 1 Entered.");
		}
		if(Vector3.Distance(player.transform.position, transform.position) > 30f && state == 1){
			state = 0;
		}
		if(health == 0){
			Destroy(gameObject);
		}
	}

	void FixedUpdate(){
		if(state == 1){
			transform.LookAt(player.transform.position, Vector3.up);
			rigidbody.AddForce(transform.forward*speed);
		}
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SendMessage("Damage", 1);
		}
	}

	void Damage(int dam){
		health = health-dam;
		Debug.Log ("Enemy took damage: " + dam);
	}

 
}
