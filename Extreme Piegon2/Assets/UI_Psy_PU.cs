using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Psy_PU : MonoBehaviour {

	public GameObject CeTrigger;
	Collider2D Moi;

	public bool InterfacePsyIsHere = false; //Pour savoir si le UI du psy est présent ou non

	//Pour vérifier si le joueur à le PU ou non
	PowerUp powerupscript;
	public GameObject LePowerUpEnQuestion;

	//Animation du Canvas
	public GameObject PsyCanvas;
	Animator animCanvasPsy;

	//Texte et bouton à apparaitre (doit être là pareil à cause de l'animation intégré à la bulle de texte)
	public Text TexteDuPsy;
	public Image BoutonX;
	public Image BoutonB;
	public string TextPsyYesPU;
	public string TextPsyNoPU;

	// Use this for initialization
	void Start () {
		animCanvasPsy = PsyCanvas.GetComponent<Animator> ();
		BoutonB.enabled = false;
		BoutonX.enabled = false;
		powerupscript = LePowerUpEnQuestion.GetComponent<PowerUp> ();
		TexteDuPsy.text = "";
		Moi = CeTrigger.GetComponent<Collider2D> ();

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
//			InterfacePsyIsHere = true;
//			animCanvasPsy.SetBool ("Apparition", true);

			BoutonB.enabled = false;
			BoutonX.enabled = false;

			if (powerupscript.BeakyGotAPowerUp == true)
				TexteDuPsy.text = TextPsyYesPU;
			if (powerupscript.BeakyGotAPowerUp == false)
				TexteDuPsy.text = TextPsyNoPU;

			StartCoroutine (TimerPsy ());
		}
	}


//	public void CheckTimerForPsy () {
//		if (InterfacePsyIsHere == true) {
//			Timer = Timer- 1 * Time.deltaTime;
//			print ("Le timer commence");
//		}
//
////		if (Timer <= 3.5 && Timer > 0 && powerupscript.BeakyGotAPowerUp == true) {
////			TexteDuPsy.text = TextPsyYesPU;
////			print ("Il reste moins de 3.5 secondes et j'ai un pu");
////		} else if (Timer <= 3.5 && Timer > 0 && powerupscript.BeakyGotAPowerUp == false) {
////			TexteDuPsy.text = TextPsyNoPU;
////			print ("Il reste moins de 3.5 secondes et j'ai PAS un pu");
////		}
//
//		if (Timer <= 0) {
//		animCanvasPsy.SetBool ("Disparition",true);
//		InterfacePsyIsHere = false;
//		//TexteDuPsy.text = "";
//		print ("No more time");
//		}
			
//	}

	IEnumerator TimerPsy(){
		Moi.enabled = false;
		InterfacePsyIsHere = true;
		animCanvasPsy.SetBool ("Apparition", true);
		yield return new WaitForSeconds (5f);
		animCanvasPsy.SetBool ("Disparition",true);
		InterfacePsyIsHere = false;
		yield return new WaitForSeconds (5f);
		TexteDuPsy.text = "";
	}

}
