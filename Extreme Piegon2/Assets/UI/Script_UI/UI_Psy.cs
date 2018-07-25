using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Psy : MonoBehaviour {

	public GameObject CeTrigger;
	Collider2D Moi;

	public bool InterfacePsyIsHere = false; //Pour savoir si le UI du psy est présent ou non

	//public GameObject Psy_UI;

	public GameObject PsyCanvas;
	Animator animPsy;

	//Texte et bouton à apparaitre
	public Text TexteDuPsy;
	public Image BoutonX;
	public Image BoutonB;
	public string QuestionPsy;
	public string ReponsePigeon;

	// Use this for initialization
	void Start () {
		animPsy = PsyCanvas.GetComponent<Animator> ();
		BoutonB.enabled = false;
		BoutonX.enabled = false;
		TexteDuPsy.text = "";
		Moi = CeTrigger.GetComponent<Collider2D> ();

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			print ("UI du psy montre toi !");
			BoutonB.enabled = false;
			BoutonX.enabled = false;
			StartCoroutine (TimerPsy ());
		}
	}

	IEnumerator TimerPsy(){
		Moi.enabled = false;
		InterfacePsyIsHere = true;
		TexteDuPsy.text = QuestionPsy;
		animPsy.SetBool ("Bouton", true);
		animPsy.SetBool ("Apparition", true);
		yield return new WaitForSeconds (4f);
		TexteDuPsy.text = "";
		TexteDuPsy.text = ReponsePigeon;
		BoutonB.enabled = true;
		BoutonX.enabled = true;
		yield return new WaitForSeconds (5f);
		animPsy.SetBool ("Disparition",true);
		InterfacePsyIsHere = false;
		yield return new WaitForSeconds (5f);
		TexteDuPsy.text = "";
	}
}
