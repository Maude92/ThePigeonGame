using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour {

	// CECI EST LE NOUVEAU SCRIPT DE MENU PAUSE, VERSION TARADIDDLES


	public GameObject mainUI;
	public GameObject powerupUI;
	public GameObject pauseUI;

	public Text countCollectiblesTextForPause;
	public Text highScoreTextForPause;

	public bool modePause;

	SauvegardeTest playerscript;

	// Use this for initialization
	void Start () {
		playerscript = GetComponent<SauvegardeTest> ();	
		modePause = false;
	}
	
	// Update is called once per frame
	void Update () {

		// Start button (... 7)						// MIS DANS UN AUTRE SCRIPT
		if (Input.GetButtonDown ("360_StartButton") || Input.GetKeyDown (KeyCode.Escape)){
			modePause = !modePause;

			if (modePause == true) {
				countCollectiblesTextForPause.text = ("Your score : " + playerscript.countCollectible);
				highScoreTextForPause.text = ("High score : " + playerscript.highScoreLevelTest);
				print ("Je pause le jeu");
				playerscript.enabled = false;
				mainUI.SetActive (false);
				powerupUI.SetActive (false);
				pauseUI.SetActive (true);
				Time.timeScale = 0;
			} else if (modePause == false) {
				print ("Je remets le jeu en marche");
				Time.timeScale = 1;
				pauseUI.SetActive (false);
				mainUI.SetActive (true);
				powerupUI.SetActive (true);
				playerscript.enabled = true;
			}
		}


	}
}
