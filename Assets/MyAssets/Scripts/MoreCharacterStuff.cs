using UnityEngine;
using System.Collections;

public class MoreCharacterStuff : MonoBehaviour {

	private int health;
	public bool hasShovel = false;
	public bool hasGun = false;
	private bool isPause = false;
	private bool lightOn = false;
	private int equipped = 0;
	private int inputStop = 0;
	public GameObject shovel;
	public GameObject gun;
	public GameObject flashlight;
	private GameObject held;
	private GameObject weapon;
	private bool dc = false;

	public Texture2D H6;
	public Texture2D H5;
	public Texture2D H4;
	public Texture2D H3;
	public Texture2D H2;
	public Texture2D H1;
	public Texture2D H0;
	private Rect hrect;
	// Use this for initialization
	void Start () {
		health = 6;
		hrect = new Rect (0f, 0f, 50f, 50f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Shovel") && inputStop == 0 && hasShovel == true && equipped != 1){
			equipped = 1;
			inputStop = 3;
			Destroy (weapon);
			float x, y, z;
			x = -0.65800f;
			y = 0f;
			z = 1.1129f;
			Vector3 hold = transform.position + (transform.forward*z) + (transform.right*x);
			hold.y = hold.y+y;
			Quaternion hold2 = transform.rotation;
			hold2.SetLookRotation(-transform.forward+(transform.up*.25f)+(-transform.right*.25f), transform.up);
			weapon = (GameObject)Instantiate(shovel, hold, hold2);
			weapon.transform.parent = transform;
		}
		else if (Input.GetButtonDown ("Gun") && inputStop == 0 && hasGun == true && equipped != 2){
			equipped = 2;
			inputStop = 3;
			Destroy (weapon);
			float x, y, z;
			x = -0.13287f;
			y = 0.55773f;
			z = 0.30531f;
			Vector3 hd = transform.position;
			hd = hd+(transform.forward*z)+(transform.right*x);
			hd.y = hd.y+y;
			Quaternion hd2 = transform.rotation;
			hd2.SetLookRotation(transform.forward, transform.up);
			weapon = (GameObject)Instantiate(gun, hd, hd2);
			weapon.transform.parent = transform;
		}
		else if (Input.GetButtonDown ("Menu") && isPause == false){
			Time.timeScale = 0;
			isPause = true;
		}
		else if (Input.GetButtonDown ("Menu") && isPause == true){
			Time.timeScale = 1;
			isPause = false;
		}
		else if (Input.GetButton ("Fire1") && equipped == 1){

		}
		else if (Input.GetButton ("Fire1") && equipped == 2){

		}
		else if (Input.GetButton ("Flashlight") && inputStop == 0 && !lightOn){
			held = (GameObject)Instantiate(flashlight, transform.position, transform.rotation);
			held.transform.parent = gameObject.transform;
			lightOn = true;
			inputStop = 5;
		}
		else if (Input.GetButton ("Flashlight") && inputStop == 0 && lightOn){
			Destroy(held);
			lightOn = false;
			inputStop = 5;
		}
		if(inputStop > 0){
			inputStop = inputStop - 1;
		}
		if (health == 0 && !dc){
			Death ();
			dc = true;
		}
	}

	void Damage (int dam){
		health = health - dam;
		if (health < 0){
			health = 0;
		}
		Debug.Log ("Took damage " + dam);
	}

	void Heal (int hel){
		health = health + hel;
		if (health > 6){
			health = 6;
		}
		Debug.Log ("Healed " + hel);
	}

	void shovelGet (){
		hasShovel = true;
		Debug.Log("Got shovel.");
	}

	void gunGet(){
		hasGun = true;
		Debug.Log ("Got gun.");
	}

	void Death(){
	}

	void OnGUI(){
		if (isPause){
		}
		if (health == 6){
			GUI.Label(hrect, H6);
		}
		if (health == 5){
			GUI.Label(hrect, H5);
		}
		if (health == 4){
			GUI.Label(hrect, H4);
		}
		if (health == 3){
			GUI.Label(hrect, H3);
		}
		if (health == 2){
			GUI.Label(hrect, H2);
		}
		if (health == 1){
			GUI.Label(hrect, H1);
		}
		if (health == 0){
			GUI.Label(hrect, H0);
		}
	}
}
