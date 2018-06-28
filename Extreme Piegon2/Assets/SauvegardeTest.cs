using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SauvegardeTest : MonoBehaviour {

	Rigidbody2D rbpiegon;

	public float maxSpeed = 5f;
	public float upForce = 100f;

	public int countCollectible;
	public int totalCollectible;
	public int highScoreLevelTest;

	public Text countCollectibleText;
	public Text totalCollectibleText;
	public Text highScoreLTestText;


	// Use this for initialization
	void Start () {
		rbpiegon = GetComponent <Rigidbody2D> ();
		countCollectible = 0;

		totalCollectible = PlayerPrefs.GetInt ("Total", 0);

		highScoreLevelTest = PlayerPrefs.GetInt ("HighScoreLTest", 0);
	}
		
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");

		rbpiegon.velocity = new Vector2 (h * maxSpeed, rbpiegon.velocity.y);
	}

	// Update is called once per frame
	void Update () {
		UserInputs ();

		countCollectibleText.text = "Count Collectible : " + countCollectible;
		totalCollectibleText.text = "Total Collectible : " + totalCollectible;
		highScoreLTestText.text = "Highscore : " + highScoreLevelTest;

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Collectible") {
			countCollectible++;
			other.gameObject.SetActive (false);
		}

		if (other.gameObject.tag == "EndOfLevel") {
			//totalCollectibleText.text = "Total Collectible : " + totalCollectible;
			totalCollectible = totalCollectible + countCollectible;
			PlayerPrefs.SetInt ("Total", totalCollectible);

			if (countCollectible > highScoreLevelTest) {
				//highScoreLTestText.text = "Highscore : " + highScoreLevelTest;
				highScoreLevelTest = countCollectible;
				PlayerPrefs.SetInt ("HighScoreLTest", countCollectible);
			}
		}
	}

	public void Reset (){
		PlayerPrefs.DeleteKey ("Total");
		PlayerPrefs.DeleteKey ("HighScoreLTest");
	}

	void UserInputs () {
	// A  button ou Up Arrow
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetButtonDown ("360_AButton")) {
			rbpiegon.velocity = Vector2.zero;
			rbpiegon.AddForce (new Vector2 (0, upForce));
		}

	// B button
		if (Input.GetButtonDown ("360_BButton")) {
			print ("Je pèse sur : B button! (dire non au psy)");
		}
			
	// Bouton X (... 2)
		if (Input.GetButtonDown ("360_XButton")){
			print ("Je pèse sur: le bouton X! (dire oui au psy)");
		}
			

	// Back button (... 6)
		if (Input.GetButtonDown ("360_BackButton")){
			print ("Je pèse sur: back button!");
		}

	// Start button (... 7)
		if (Input.GetButtonDown ("360_StartButton")){
			print ("Je pèse sur: start button!");
		}

	// D-PAD
	//RIGHT d-pad...
//		if (Input.GetAxis ("360_HorizontalDPAD")>0.001){
//			print ("Right D-PAD button!");
//		}
	// LEFT d-pad....
//		if(Input.GetAxis ("360_HorizontalDPAD")<0){
//			print ("Left D-PAD button!");
//		}
	// UP d-pad...
//		if (Input.GetAxis("360_VerticalDPAD")>0.001){
//			print ("Up D-PAD button!");
//		}
	// DOWN d-pad...
//		if (Input.GetAxis("360_VerticalDPAD")<0){
//			print ("Down D-PAD button!");
//		}

	// LES TRIGGERS
		//Triggers
		if (Input.GetAxis ("360_TriggerL") > 0.001 && Input.GetAxis ("360_TriggerR") > 0.001) {
			print ("Je pèse sur les deux triggers en même temps!");
		} else if (Input.GetAxis ("360_TriggerL") > 0.001 && Input.GetAxis ("360_TriggerR") < 0.001) {
			print ("Je pèse juste sur le trigger gauche");
		} else if (Input.GetAxis ("360_TriggerL") < 0.001 && Input.GetAxis ("360_TriggerR") > 0.001) {
			print ("Je pèse juste sur le trigger droit");
		}

		// Triggers séparés
//		if (Input.GetAxis ("360_TriggerL") > 0.001){
//			print ("Je pèse sur le trigger gauche!!");
//		}
//
//		if (Input.GetAxis ("360_TriggerR") > 0.001) {
//			print ("Je pèse sur le trigger droit!!");
//		}

	}
}
