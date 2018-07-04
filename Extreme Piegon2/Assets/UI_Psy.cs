using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Psy : MonoBehaviour {

	//Temps avant disparition
	public float Timer;
	public bool InterfacePsyIsHere = false; //Pour savoir si le UI du psy est présent ou non

	//public GameObject Psy_UI; //la bulle de texte (AVANT)
	public GameObject BullePsy; //la bulle de texte (dans le canevas)
	Animator animBulle;
	public Image BullePsygeon;

	public GameObject PsyCanvas;
	Animator animBouton;

	//Texte et bouton à apparaitre
	public Text TexteDuPsy;
	public Image BoutonX;
	public Image BoutonB;
	public string QuestionPsy;
	public string ReponsePigeon;

	// Use this for initialization
	void Start () {
		animBulle = BullePsy.GetComponent<Animator> ();
		animBouton = PsyCanvas.GetComponent<Animator> ();
		BoutonB.enabled = false;
		BoutonX.enabled = false;
		BullePsygeon.enabled = false;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			print ("UI du psy montre toi !");
			BullePsygeon.enabled = true;
			animBulle.SetBool ("Apparition", true);
			//animBulle.SetBool ("Disparition", false);
			InterfacePsyIsHere = true;

		}
	}
	
	// Update is called once per frame
	void Update () {
		CheckTimerForPsy ();
	}

	public void CheckTimerForPsy () {
		if (InterfacePsyIsHere == true) {
			Timer = Timer- 1 * Time.deltaTime;
		}

		if (Timer <= 28.5) {
			TexteDuPsy.text = QuestionPsy;
		}

		if (Timer <= 23 && Timer > 0) {
			TexteDuPsy.text = "";
			TexteDuPsy.text = ReponsePigeon;
			BoutonB.enabled = true;
			BoutonX.enabled = true;
		}

		if (Timer <= 0) {
			//animBulle.SetBool ("Disparition", true);
			//animBulle.SetBool ("Dead", true);
			//animBulle.SetBool ("Apparition", false);
			animBouton.SetBool ("Disparition",true);
//			BoutonB.enabled = false;
//			BoutonX.enabled = false;
			InterfacePsyIsHere = false;
		}

		if (InterfacePsyIsHere == false) {
			//animBouton.SetBool ("Disparition", false);
			TexteDuPsy.text = "";
		}
	}
}
