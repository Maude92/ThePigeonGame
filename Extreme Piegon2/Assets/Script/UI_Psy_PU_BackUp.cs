using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Psy_PU_BackUp : MonoBehaviour {

	UI_Psy_PU CeSript;
	public GameObject CeTrigger;

	//Temps avant disparition
	public float Timer;
	public bool InterfacePsyIsHere = false; //Pour savoir si le UI du psy est présent ou non

	//Pour vérifier si le joueur à le PU ou non
	PowerUp powerupscript;
	public bool GotThePU = false;
	public GameObject LePowerUpEnQuestion;

	//public GameObject Psy_UI; //la bulle de texte (AVANT)
	public GameObject BullePsy; //la bulle de texte (dans le canevas)
	Animator animBulle;
	public Image BullePsygeon;

	public GameObject PsyCanvas;
	Animator animBouton;

	//Texte et bouton à apparaitre (doit être là pareil à cause de l'animation intégré à la bulle de texte)
	public Text TexteDuPsy;
	public Image BoutonX;
	public Image BoutonB;
	public string TextPsyYesPU;
	public string TextPsyNoPU;
	//public string ReponsePigeon;

	// Use this for initialization
	void Start () {
		animBulle = BullePsy.GetComponent<Animator> ();
		animBouton = PsyCanvas.GetComponent<Animator> ();
		BoutonB.enabled = false;
		BoutonX.enabled = false;
		BullePsygeon.enabled = false;

		CeSript = CeTrigger.GetComponent<UI_Psy_PU> ();
		powerupscript = LePowerUpEnQuestion.GetComponent<PowerUp> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			InterfacePsyIsHere = true;
			ActivateTheBubble ();
			animBulle.SetBool ("Apparition", true);
			animBulle.SetBool ("Disparition", false);

		}
	}

	// Update is called once per frame
//	void Update () {
//		CheckTimerForPsy ();
//	}

	public void CheckTimerForPsy () {
		if (InterfacePsyIsHere == true) {
			Timer = Timer- 1 * Time.deltaTime;
		}

		if (Timer <= 3.5 && powerupscript.BeakyGotAPowerUp == true) {
			TexteDuPsy.text = TextPsyYesPU;
			GotThePU = true;
		} else if (Timer <= 3.5 && powerupscript.BeakyGotAPowerUp == false) {
			TexteDuPsy.text = TextPsyNoPU;
			GotThePU = false;
		}


		if (Timer <= 0) {
			animBouton.SetBool ("Disparition",true);
			//			BoutonB.enabled = false;
			//			BoutonX.enabled = false;
			InterfacePsyIsHere = false;
			Invoke ("DeactivateTheBubble", 2.2f);
		}

		if (InterfacePsyIsHere == false) {
			//animBouton.SetBool ("Disparition", false);
			TexteDuPsy.text = "";
		}
	}

	void DeactivateTheBubble (){
		animBouton.SetBool ("Disparition",false);
		animBulle.SetBool ("Apparition", false);
		animBulle.SetBool ("Disparition", true);
		BullePsygeon.enabled = false;
		CeSript.enabled = false;
	}

	void ActivateTheBubble (){
		BullePsygeon.enabled = true;
	}
}
