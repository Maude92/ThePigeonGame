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

	//Invincibilité --> = 2
	public GameObject PowerUp_InvincibilityWorld;
	public Image PowerUp_InvicibilityUI;

	public bool BeakyGotAPowerUp;
	public int WichPowerUp;

	SpriteRenderer spriterendererpowerup;
	Collider2D collider2dpowerup;


	void Start (){
		PowerUp_SoDUI.enabled = false;
		PowerUp_InvicibilityUI.enabled = false;
		BeakyGotAPowerUp = false;

		spriterendererpowerup = GetComponent<SpriteRenderer> ();
		collider2dpowerup = GetComponent<Collider2D> ();

		TrigDestruction.SetActive (false);
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
			//Désactiver le PowerUp du World et activer le PowerUp dans la box
			//PowerUp_SoDWorld.SetActive (false); //faire disparaitre le powerup dans le monde
			spriterendererpowerup.enabled = false;
			collider2dpowerup.enabled = false;
			PowerUp_SoDUI.enabled = true; //mettre powerup dans la box

			//Désactiver les autres dans la box
			PowerUp_InvicibilityUI.enabled = false;
			//... autre s'il y a lieu
		}

		//Invincibility
		if (WichPowerUp == 2) {
			//PowerUp_InvincibilityWorld.SetActive (false);
			spriterendererpowerup.enabled = false;
			collider2dpowerup.enabled = false;
			PowerUp_InvicibilityUI.enabled = true;

			PowerUp_SoDUI.enabled = false;
		}
	}

	public void ActivatePowerUp(){
		if (WichPowerUp == 1) {
			PowerUp_SoDUI.enabled = false;
			TrigDestruction.SetActive (true);
			TimerSoD = 3;
			TimerSoD = TimerSoD - 1 * Time.deltaTime;
			if (TimerSoD <= 0) {
				TrigDestruction.SetActive (false);
			}

		}

		if (WichPowerUp == 2) {
			PowerUp_InvicibilityUI.enabled = false;
			print ("Un jours il y aura qqchose ici");
			//dommage = 0 pendant x secondes
		}
	}
}
