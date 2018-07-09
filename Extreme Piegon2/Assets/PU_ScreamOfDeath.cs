using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PU_ScreamOfDeath : MonoBehaviour {

	//Scream of Death --> = 1
	public GameObject PowerUp_SoDWorld;
	public Image PowerUp_SoDUI;

	//Invincibilité --> = 2
	public GameObject PowerUp_InvincibilityWorld;
	public Image PowerUp_InvicibilityUI;

	public bool BeakyGotAPowerUp;
	public int WichPowerUpDoesBeakyHave;

	void Start (){
		PowerUp_SoDUI.enabled = false;
		BeakyGotAPowerUp = false;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player" && BeakyGotAPowerUp == false) {
			BeakyGotAPowerUp = true; //à accéder avec le script de contrôle pour activer le PowerUp
			PowerUpCheck ();
		}
	}

	public void PowerUpCheck(){

		//Désactiver les PowerUp dans la box lorsque vide
		if (WichPowerUpDoesBeakyHave == 0) {
			PowerUp_SoDUI.enabled = false;
			PowerUp_InvicibilityUI.enabled = false;
		}

		//Scream of Death
		if (WichPowerUpDoesBeakyHave == 1) {
			//Désactiver le PowerUp du World et activer le PowerUp dans la box
			PowerUp_SoDWorld.SetActive (false); //faire disparaitre le powerup dans le monde
			PowerUp_SoDUI.enabled = true; //mettre powerup dans la box

			//Désactiver les autres dans la box
			PowerUp_InvicibilityUI.enabled = false;
			//... autre s'il y a lieu
		}

		//Invincibility
		if (WichPowerUpDoesBeakyHave == 2) {
			PowerUp_InvincibilityWorld.SetActive (false);
			PowerUp_InvicibilityUI.enabled = true;

			PowerUp_SoDUI.enabled = false;
		}
	}
		
}
