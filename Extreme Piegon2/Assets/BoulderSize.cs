using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoulderSize : MonoBehaviour {

	public bool InterfacePsyIsHere = false; //Pour savoir si le UI du psy est présent ou non

	public bool timeToAnswer;
	public bool choixYesX;
	public bool choixNoB;
	public bool choixFait;

	public GameObject CeTrigger;
	public GameObject PsyCanvas;

	Collider2D Moi;
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
		choixNoB = false;
		choixYesX = false;
		choixFait = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToAnswer == true) {
			if (Input.GetButtonDown ("360_XButton")) {
				animPsy.SetBool ("Yes", true);
				Time.timeScale = 1;
				choixYesX = true;
				choixNoB = false;
				choixFait = true;
				timeToAnswer = false;
			} else if (Input.GetButtonDown ("360_BButton")) {
				animPsy.SetBool ("No", true);
				Time.timeScale = 1;
				choixYesX = false;
				choixNoB = true;
				choixFait = true;
				timeToAnswer = false;
			}
		}

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Boulder") {
			print ("Le psy se pose des questions...!");

			print ("UI du psy montre toi !");
			BoutonB.enabled = false;
			BoutonX.enabled = false;
			StartCoroutine (TimerPsy ());

			// Faire afficher le texte du psy ("A giant boulder? Are you sure about that?")						FAIT!

			// Ralentir le temps pour laisser le temps au joueur de lire le texte et de faire un choix			FAIT!

			// Attendre un certain nombre de temps																FAIT!

			// Option 1 : Le joueur a appuyé sur X (Oui)
				
				// X % de chance que ça empire (Bigger) 
				// X % de chance que ça devienne moins pire (Smaller)
				// X % de chance que ça reste normal (Normal)

			// Option 2 : Le joueur a appuyé sur B (Non)

				// X % de chance que ça empire (Bigger) ("No, you're right. Actually... it was WAY WORSE!")
				// X % de chance que ça devienne moins pire (Smaller) ("Ok, ok. Maybe I exagerated a little")

			// Si aucun choix n'est fait, le size reste normal, et le temps revient à la vitesse normale
		}
	}

	IEnumerator TimerPsy(){
		Moi.enabled = false;
		InterfacePsyIsHere = true;
		TexteDuPsy.text = QuestionPsy;
		animPsy.SetBool ("Bouton", true);
		animPsy.SetBool ("Apparition", true);
		yield return new WaitForSeconds (4f);
		Time.timeScale = 0.5f;
		timeToAnswer = true;
		TexteDuPsy.text = "";
		TexteDuPsy.text = ReponsePigeon;
		BoutonB.enabled = true;
		BoutonX.enabled = true;
		yield return new WaitForSeconds (4f);
		Time.timeScale = 1;
		timeToAnswer = false;
		animPsy.SetBool ("Disparition",true);
		InterfacePsyIsHere = false;
		yield return new WaitForSeconds (5f);
		TexteDuPsy.text = "";
	}
}
