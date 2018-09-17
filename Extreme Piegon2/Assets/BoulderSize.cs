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
	public bool itGetsBetter;
	public bool itGetsWorse;

//	public float goBig = 2.3f;
//	public float goNormal = 1.4f;
//	public float goSmall = 0.4f;

	public int outcome;

	public GameObject CeTrigger;
	public GameObject PsyCanvas;
	public GameObject boulderNormal;
	public GameObject boulderParent;

	Collider2D Moi;
	Rigidbody2D rbBoulder;
	Animator animPsy;
	Animator animBoulder;

	//Texte et bouton à apparaitre
	public Text TexteDuPsy;
	public Image BoutonX;
	public Image BoutonB;
	public string QuestionPsy;
	public string ReponsePigeon;


	// Use this for initialization
	void Start () {
		animPsy = PsyCanvas.GetComponent<Animator> ();
		animBoulder = boulderParent.GetComponent<Animator> ();
		Moi = CeTrigger.GetComponent<Collider2D> ();
		rbBoulder = boulderNormal.GetComponent<Rigidbody2D> ();

		BoutonB.enabled = false;
		BoutonX.enabled = false;
		TexteDuPsy.text = "";
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
				RandomOutcomeForBeaky ();
			} else if (Input.GetButtonDown ("360_BButton")) {
				animPsy.SetBool ("No", true);
				Time.timeScale = 1;
				choixYesX = false;
				choixNoB = true;
				choixFait = true;
				timeToAnswer = false;
				RandomOutcomeForBeaky ();
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

	void RandomOutcomeForBeaky(){												// CHOISIR LES PROBABILITÉS QU'ON VEUT!
		if (choixYesX == true) {
			outcome = Random.Range (0, 10);											// SI ON RÉPOND OUI
			print ("Le résultat de ma valeur outcome : " + outcome);
			if (outcome >= 0 && outcome <= 6) {											// 70 % que ça devienne plus gros
				// Go Bigger
				animBoulder.SetBool ("Big", true);
			} else if (outcome > 6 && outcome <= 8) {									// 20 % que ça devienne plus petit
				// Go Small
				animBoulder.SetBool ("Small", true);
			} else if (outcome > 8) {													// 10 % que ça reste normal
				print ("Rien ne change!");
			}
		} else if (choixNoB == true) {												// SI ON RÉPOND NON
			outcome = Random.Range (0, 10);
			print ("Le résultat de ma valeur outcome : " + outcome);
			if (outcome >= 0 && outcome <= 5) {											// 50 % que ça devienne plus petit
				// Go Small
				animBoulder.SetBool ("Small", true);
			} else if (outcome > 5 && outcome <= 8) {									// 40 % que ça devienne plus gros
				// Go Bigger
				animBoulder.SetBool ("Big", true);
			} else if (outcome > 8) {													// 10 % que ça reste normal
				print ("Rien ne change!");
			}

		}
	}
}
