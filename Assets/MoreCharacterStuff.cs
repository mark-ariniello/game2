using UnityEngine;
using System.Collections;

public class MoreCharacterStuff : MonoBehaviour {

	private int health;
	public bool hasShovel = false;
	public bool hasGun = false;
	private bool isPause = false;
	private int equipped = 0;
	private int inputStop = 0;
	// Use this for initialization
	void Start () {
		health = 6;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Shovel") && inputStop == 0 && hasShovel == true && equipped != 1){
			equipped = 1;
			inputStop = 3;
		}
		else if (Input.GetButtonDown ("Gun") && inputStop == 0 && hasGun == true && equipped != 2){
			equipped = 2;
			inputStop = 3;
		}
		else if (Input.GetButtonDown ("Menu") && isPause == false){
			Time.timeScale = 0;
			isPause = true;
		}
		else if (Input.GetButtonDown ("Menu") && isPause == true){
			Time.timeScale = 1;
			isPause = false;
		}
		if(inputStop > 0){
			inputStop = inputStop - 1;
		}
	}

	void Damage (int dam){
		health = health - dam;
		if (health < 0){
			health = 0;
		}
	}

	void Heal (int hel){
		health = health + hel;
		if (health > 6){
			health = 6;
		}
	}

	void shovelGet (){
		hasShovel = true;
		Debug.Log("Got shovel.");
	}

	void gunGet(){
		hasGun = true;
	}

	void OnGui(){
		if (isPause){
		}
	}
}
