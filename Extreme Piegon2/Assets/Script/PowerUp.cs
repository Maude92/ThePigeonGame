using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour {

	//Scream of Death --> = 1
	public GameObject PowerUp_SoDWorld;
	public Image PowerUp_SoDUI;
	public GameObject TrigDestruction;
	public float TimerSoD;
	public bool killeverybody;

	//Invincibilité --> = 2
	public GameObject PowerUp_InvincibilityWorld;
	public Image PowerUp_InvicibilityUI;
	public GameObject player;
	public GameObject laCamera;
	public GameObject goFaster;
//	public float speedupthatpigeon;
//	public float speedupthatcamera;
//	public float speedupthatgofaster;
	SauvegardeTest scriptplayer;
	MoveCameraNEW movecameranewscript;
	GoFaster gofasterscript;
	//public GameObject colliderenfant;
	//Collider2D colliderPlayer;
	//Collider2D colliderPlayerForPowerup;

	public bool BeakyGotAPowerUp;
	public int WichPowerUp;

	SpriteRenderer spriterendererpowerup;
	Collider2D collider2dpowerup;

	public GameObject miniBeakyUI;
	Animator animMiniBeakyUI;

	public GameObject powerUpCanvas;
	Animator animpowerupcanvas;

	public GameObject canvasRawrrr;
	public GameObject particulesPowerup;
	public GameObject particulesScream;
	public GameObject particulesInvincible;


	void Start (){
		PowerUp_SoDUI.enabled = false;
		PowerUp_InvicibilityUI.enabled = false;
		BeakyGotAPowerUp = false;

		spriterendererpowerup = GetComponent<SpriteRenderer> ();
		collider2dpowerup = GetComponent<Collider2D> ();

		scriptplayer = player.GetComponent<SauvegardeTest> ();
		movecameranewscript = laCamera.GetComponent<MoveCameraNEW> ();
		gofasterscript = goFaster.GetComponent<GoFaster> ();

		animMiniBeakyUI = miniBeakyUI.GetComponent<Animator> ();
		animpowerupcanvas = powerUpCanvas.GetComponent<Animator> ();

		//TrigDestruction.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player" && BeakyGotAPowerUp == false) {
			
			BeakyGotAPowerUp = true; //à accéder avec le script de contrôle pour activer le PowerUp
			PowerUpCheck ();
		}
	}

	void PowerUpCheck(){

		//Désactiver les PowerUp dans la box lorsque vide
		if (WichPowerUp == 0) {
			PowerUp_SoDUI.enabled = false;
			PowerUp_InvicibilityUI.enabled = false;
		}

		//Scream of Death
		if (WichPowerUp == 1) {
			particulesScream.transform.position = gameObject.transform.position;
			particulesScream.SetActive (true);
			//Désactiver le PowerUp du World et activer le PowerUp dans la box
			//PowerUp_SoDWorld.SetActive (false); //faire disparaitre le powerup dans le monde
			StartCoroutine (WaitBeforeByeBye());														// POUR JUICE
			//spriterendererpowerup.enabled = false;
			collider2dpowerup.enabled = false;
			PowerUp_SoDUI.enabled = true; //mettre powerup dans la box
			animpowerupcanvas.SetBool ("Powerup", true);
			//Désactiver les autres dans la box
			PowerUp_InvicibilityUI.enabled = false;
			//... autre s'il y a lieu
		}

		//Invincibility
		if (WichPowerUp == 2) {
			particulesInvincible.transform.position = gameObject.transform.position;
			particulesInvincible.SetActive (true);
			//PowerUp_InvincibilityWorld.SetActive (false);
			StartCoroutine (WaitBeforeByeBye());
			//spriterendererpowerup.enabled = false;
			collider2dpowerup.enabled = false;
			PowerUp_InvicibilityUI.enabled = true;
			animpowerupcanvas.SetBool ("Powerup", true);
			PowerUp_SoDUI.enabled = false;
		}
	}

	public void ActivatePowerUp(){
		if (WichPowerUp == 1) {										// SCREAM OF DEATH
			//PowerUp_SoDUI.enabled = false;
			StartCoroutine (KillEverybodyNow ());
//			killeverybody = true;
			//TrigDestruction.SetActive (true);
//			TimerSoD = 1;
//			TimerSoD = TimerSoD - 1 * Time.deltaTime;
//			if (TimerSoD <= 0) {
//				TrigDestruction.SetActive (false);
//				killeverybody = false;
//			}
		}

		if (WichPowerUp == 2) {										// INVINCIBLE
			//PowerUp_InvicibilityUI.enabled = false;
			StartCoroutine (ImInvincible ());
			//print ("Un jours il y aura qqchose ici");
			//dommage = 0 pendant x secondes
		}
	}
		
	IEnumerator KillEverybodyNow () {												
		animpowerupcanvas.SetBool ("PowerupUsed", true);
		animMiniBeakyUI.SetBool ("Scream", true);
		//Time.timeScale = 0.75f;														// À RAJOUTER SI ON VEUT QUE LE TEMPS RALENTISSE PENDANT QU'ON UTILISE LE POWERUP
		canvasRawrrr.SetActive (true);
		player.layer = LayerMask.NameToLayer ("Fuckall");
		killeverybody = true;
		yield return new WaitForSeconds (0.2f);
		killeverybody = false;
		//TrigDestruction.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		//Time.timeScale = 1;															// SAME
		player.layer = LayerMask.NameToLayer ("Player");
		yield return new WaitForSeconds (1.5f);
		canvasRawrrr.SetActive (false);
		PowerUp_SoDUI.enabled = false;
	}

	IEnumerator ImInvincible () {
		particulesPowerup.SetActive (true);
		animpowerupcanvas.SetBool ("PowerupUsed", true);
		animMiniBeakyUI.SetBool ("Invincible", true);
		print ("Un jour le powerup commencera maintenant.");
		gofasterscript.newSpeed = 9;
		movecameranewscript.speed = 6;
		scriptplayer.maxSpeed = 10;
		movecameranewscript.downSpeed = 0.5f;
		player.layer = LayerMask.NameToLayer ("Fuckall");
		yield return new WaitForSeconds (5f);
		gofasterscript.newSpeed = 4.5f;
		movecameranewscript.speed = 3;
		scriptplayer.maxSpeed = 5;
		movecameranewscript.downSpeed = 0.25f;
		player.layer = LayerMask.NameToLayer ("Player");
		print ("Un jour le powerup sera fini maintenant.");
		PowerUp_InvicibilityUI.enabled = false;
	}

	IEnumerator WaitBeforeByeBye(){
		yield return new WaitForSeconds (2);
		spriterendererpowerup.enabled = false;
	}
}
