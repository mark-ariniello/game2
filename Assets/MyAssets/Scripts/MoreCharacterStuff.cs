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

	public Texture2D B5;
	public Texture2D B4;
	public Texture2D B3;
	public Texture2D B2;
	public Texture2D B1;
	public Texture2D B0;
	private Rect brect;
	
	public int ammo = 0;

	private int fBattery = 10000;
	private int fb, f5, f4, f3, f2, f1;
	
	private int controlInstruct = 0;
	private int shovInstruct = 0;
	private int gunInstruct = 0;
	private Rect irect;
	
	public bool newplayer = false;
	private int mercy = 0;
	// Use this for initialization
	void Start () {
		health = 6;
		hrect = new Rect (0f, 0f, 50f, 50f);
		brect = new Rect (5f, 55f, 50f, 25f);
		irect = new Rect (180f, 0f, 200f, 100f);
		fb = fBattery;
		f5 = (fBattery*4)/5;
		f4 = (fBattery*3)/5;
		f3 = (fBattery*2)/5;
		f2 = fBattery/5;
		f1 = 0;
		if(newplayer){
		  controlInstruct = 300;
		}
		ammo = PlayerPrefs.GetInt("Ammo");
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
		else if (Input.GetButtonDown ("Flashlight") && inputStop == 0 && !lightOn && fb > f1){
			held = (GameObject)Instantiate(flashlight, transform.position, transform.rotation);
			held.transform.parent = gameObject.transform;
			lightOn = true;
		}
		else if (Input.GetButtonDown ("Flashlight") && inputStop == 0 && lightOn){
			Destroy(held);
			lightOn = false;
		}
		if(inputStop > 0){
			inputStop = inputStop - 1;
		}
		if (health == 0 && !dc){
			Death ();
			dc = true;
		}
		if (lightOn && fb <= f1){
			lightOn = false;
			Destroy (held);
		}
		if (mercy != 0){
		    mercy--;
		}
	}

	void FixedUpdate(){
		if (lightOn && fb > f1){
			fb--;
		}
		if (Input.GetButton ("Fire1") && equipped == 1){
			if(!weapon.animation.IsPlaying("Swing")){
				weapon.animation.Play("Swing");
				Ray swing = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
				RaycastHit hit;
				if ((Physics.SphereCast(swing, 1f, out hit, 10f) && hit.transform.gameObject.tag == "Enemy") || (Physics.Raycast(swing, out hit, 10f) && hit.transform.gameObject.tag == "Enemy")){
					hit.transform.gameObject.SendMessage("Damage", 1);
				}
			}
		}
		if (Input.GetButton ("Fire1") && equipped == 2){
			Animation hold = weapon.GetComponentsInChildren<Animation>()[0];
			if(!hold.IsPlaying("Fire") && ammo != 0){
				hold.Play ("Fire");
				Ray fire = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
				RaycastHit hit;
				if (Physics.Raycast(fire, out hit) && hit.transform.gameObject.tag == "Enemy"){
					hit.transform.gameObject.SendMessage("Damage", 2);
				}
				ammo--;
			}
		}
		if (Input.GetButton("Fire1") && equipped == 2 && ammo == 0){
		    Debug.Log("Out of Ammo!");
		}
		if (controlInstruct != 0){
		    controlInstruct--;
		}
		if (shovInstruct != 0){
		    shovInstruct--;
		}
		if (gunInstruct != 0){
		    gunInstruct--;
		}
	}

	void Damage (int dam){
	    if(mercy == 0){
		    health = health - dam;
		    if (health < 0){
			    health = 0;
		    }
		    Debug.Log ("Took damage " + dam);
			mercy = 30;
		}
	}

	void Heal (int hel){
		health = health + hel;
		if (health > 6){
			health = 6;
		}
		Debug.Log ("Healed " + hel);
	}

	void batteryGet(){
		fb = fBattery;
		Debug.Log("Got battery pack.");
	}

	void shovelGet (){
		hasShovel = true;
		Debug.Log("Got shovel.");
		shovInstruct = 300;
	}

	void gunGet(){
		hasGun = true;
		Debug.Log ("Got gun.");
		gunInstruct = 300;
	}
	
	void ammoGet(int a){
	    ammo = ammo + a;
		Debug.Log ("Got ammo: " + a);
	}

	void Death(){
		Application.LoadLevel("DeathScene");
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
		if (fb > f5){
			GUI.Label(brect, B5);
		}
		if (fb > f4 && fb <= f5){
			GUI.Label(brect, B4);
		}
		if (fb > f3 && fb <= f4){
			GUI.Label(brect, B3);
		}
		if (fb > f2 && fb <= f3){
			GUI.Label(brect, B2);
		}
		if (fb > f1 && fb <= f2){
			GUI.Label(brect, B1);
		}
		if (fb == f1){
			GUI.Label(brect, B0);
		}
		if (hasGun){
		    GUI.Label(new Rect(0f, 180f, 50, 50), "Ammo: " + ammo);
		}
		if (controlInstruct != 0){
		    GUI.Label(irect, "Use wasd to move; press f to toggle your flashlight.");
		}
		if (shovInstruct != 0){
		    GUI.Label(irect, "Press 1 to equip your shovel, left click to swing.");
		}
		if (gunInstruct != 0){
		    GUI.Label(irect, "Press 2 to equip your gun, left click to fire.");
		}
	}
}
