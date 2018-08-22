using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SauvegardeTest : MonoBehaviour {

	Rigidbody2D rbpiegon;
	Animator anim;

	public float maxSpeed = 5f;
	public float upForce = 100f;
	public float sphereRadius = 2f;

	public int countCollectible;
	public int totalCollectible;
	public int highScoreLevelTest;
	public int quelLevel;
	//public int totaletoilew1l1;
	public int highScoreEtoileW1L1;
	public int highScoreEtoileW1L2;

	public bool ayoye;

	public Text countCollectibleText;
	public Text totalCollectibleText;
	public Text highScoreLTestText;
	public Text countCollectibleTextEndOfLevel;
	public Text highScoreLTestTextEndOfLevel;

	public int nbVie;
	public int nbEtoile;
	public GameObject troisetoiles;
	public GameObject deuxetoiles;
	public GameObject uneetoile;

	public GameObject mainUI;
	public GameObject dieUI;
	public GameObject powerupUI;
	public GameObject nextlevelUI;
	public GameObject newBeakyUI;
	public GameObject psygeonUI;
	//public GameObject pauseUI;

//	public GameObject coeur3;
//	public GameObject coeur3empty;
//	public GameObject coeur2;
//	public GameObject coeur2empty;
//	public GameObject coeur1;
//	public GameObject coeur1empty;

	public GameObject plume3;
	public GameObject plume2;
	public GameObject plume1;

	Animator animPlume3;
	Animator animPlume2;
	Animator animPlume1;

	public GameObject particlesHurt;
	public GameObject particlesPlume;
	public GameObject particlesBerry0;
	public GameObject particlesBerry1;
	public GameObject particlesBerry2;
	public GameObject particlesBerry3;
	public GameObject particlesBerry4;

	MoveCameraNEW movecameranewscript;
	public GameObject laCamera;
	public GameObject spawnBeaky;

	PowerUp powerupscriptpremier;
	PowerUp powerupscriptdeuxieme;
	public GameObject powerup1;
	public GameObject powerup2;

	public GameObject miniBeakyUI;
	Animator animMiniBeakyUI;

	MenuPause lemenupause;

//	public GameObject targetCollectibles;
//	public float speedToTarget;

	SpriteRenderer spriterendererplayer;
	Collider2D colliderplayer;

	// Use this for initialization
	void Start () {
		rbpiegon = GetComponent <Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		movecameranewscript = laCamera.GetComponent<MoveCameraNEW> ();
		powerupscriptpremier = powerup1.GetComponent<PowerUp> ();
		powerupscriptdeuxieme = powerup2.GetComponent<PowerUp> ();
		spriterendererplayer = GetComponent<SpriteRenderer> ();
		lemenupause = GetComponent <MenuPause> ();
		colliderplayer = GetComponent<Collider2D> ();

		animPlume3 = plume3.GetComponent<Animator> ();
		animPlume2 = plume2.GetComponent<Animator> ();
		animPlume1 = plume1.GetComponent<Animator> ();
		animMiniBeakyUI = miniBeakyUI.GetComponent<Animator> ();

		animPlume3.SetBool ("Move", true);

		lemenupause.enabled = true;

		countCollectible = 0;

		totalCollectible = ZPlayerPrefs.GetInt ("Total", 0);

		highScoreLevelTest = ZPlayerPrefs.GetInt ("HighScoreLTest", 0);

		//totaletoilew1l1 = ZPlayerPrefs.GetInt ("EtoileW1L1", 0);

		highScoreEtoileW1L1 = ZPlayerPrefs.GetInt ("HSEtoileW1L1", 0);

		highScoreEtoileW1L2 = ZPlayerPrefs.GetInt ("HSEtoileW1L2", 0);

		nbVie = 3;

		ayoye = false;
	}
		
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");

		rbpiegon.velocity = new Vector2 (h * maxSpeed, rbpiegon.velocity.y);
	}

	// Update is called once per frame
	void Update () {
		UserInputs ();

		countCollectibleText.text = "" + countCollectible;
		totalCollectibleText.text = "Total Collectible : " + totalCollectible;
		highScoreLTestText.text = "Highscore : " + highScoreLevelTest;

		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
		anim.SetFloat ("Recule", Input.GetAxis ("Horizontal"));

		//print ("Vie : " + nbVie);
	}

	void OnTriggerEnter2D (Collider2D other){
		
		// LES COLLECTIBLES
		if (other.gameObject.tag == "Collectible") {
			countCollectible++;
			//other.gameObject.SetActive (false);
			animMiniBeakyUI.SetBool ("Eat", true);

			// POUR LES PARTICULES
			if (!particlesBerry0.activeInHierarchy) {
				particlesBerry0.transform.position = other.transform.position;
				particlesBerry0.SetActive (true);
			} else if (particlesBerry0.activeInHierarchy && !particlesBerry1.activeInHierarchy && !particlesBerry2.activeInHierarchy && !particlesBerry3.activeInHierarchy) {
				particlesBerry1.transform.position = other.transform.position;
				particlesBerry1.SetActive (true);
			} else if (particlesBerry0.activeInHierarchy && particlesBerry1.activeInHierarchy && !particlesBerry2.activeInHierarchy && !particlesBerry3.activeInHierarchy) {
				particlesBerry2.transform.position = other.transform.position;
				particlesBerry2.SetActive (true);
			} else if (particlesBerry0.activeInHierarchy && particlesBerry1.activeInHierarchy && particlesBerry2.activeInHierarchy && !particlesBerry3.activeInHierarchy) {
				particlesBerry3.transform.position = other.transform.position;
				particlesBerry3.SetActive (true);
			} else if (particlesBerry0.activeInHierarchy && particlesBerry1.activeInHierarchy && particlesBerry2.activeInHierarchy && particlesBerry3.activeInHierarchy) {
				particlesBerry4.transform.position = other.transform.position;
				particlesBerry4.SetActive (true);
			}
		}


		// FIN DU LEVEL
		if (other.gameObject.tag == "EndOfLevel") {
			//totalCollectibleText.text = "Total Collectible : " + totalCollectible;

			if (countCollectible > highScoreLevelTest) {
				//highScoreLTestText.text = "Highscore : " + highScoreLevelTest;
				highScoreLevelTest = countCollectible;
				ZPlayerPrefs.SetInt ("HighScoreLTest", countCollectible);
			}

			movecameranewscript.speed = 0;
			maxSpeed = 0;
			spriterendererplayer.enabled = false;
			countCollectibleTextEndOfLevel.text = ("Your score : " + countCollectible);
			highScoreLTestTextEndOfLevel.text = ("High score : " + highScoreLevelTest);
			mainUI.SetActive (false);
			newBeakyUI.SetActive (false);
			psygeonUI.SetActive (false);
			powerupUI.SetActive (false);
			nextlevelUI.SetActive (true);
			totalCollectible = totalCollectible + countCollectible;
			ZPlayerPrefs.SetInt ("Total", totalCollectible);


				// POUR LES ÉTOILES

				// COMBIEN D'ÉTOILES?												// ON CHANGERA LES CONDITIONS PLUS TARD QUAND ON SAURA C'EST QUOI QUE ÇA PREND POUR LES ÉTOILES
			if (countCollectible < 50) {
				nbEtoile = 1;
			} else if (countCollectible >= 50 && countCollectible <= 69) {
				nbEtoile = 2;
			} else if (countCollectible == 70) {
				nbEtoile = 3;
			}

				// AFFICHE LES ÉTOILES
			if (quelLevel == 1) {
				
				if (nbEtoile > highScoreEtoileW1L1) {
					highScoreEtoileW1L1 = nbEtoile;
					ZPlayerPrefs.SetInt ("HSEtoileW1L1", nbEtoile);
				} else if (nbEtoile <= highScoreEtoileW1L1) {
					highScoreEtoileW1L1 = highScoreEtoileW1L1;
					ZPlayerPrefs.SetInt ("HSEtoileW1L1", highScoreEtoileW1L1);
				}

				if (nbEtoile == 1) {
					uneetoile.SetActive (true);
					deuxetoiles.SetActive (false);
					troisetoiles.SetActive (false);
				} else if (nbEtoile == 2) {
					uneetoile.SetActive (false);
					deuxetoiles.SetActive (true);
					troisetoiles.SetActive (false);
				} else if (nbEtoile == 3) {
					uneetoile.SetActive (false);
					deuxetoiles.SetActive (false);
					troisetoiles.SetActive (true);
				}

			} else if (quelLevel == 2) {				
				if (nbEtoile > highScoreEtoileW1L2) {
					highScoreEtoileW1L2 = nbEtoile;
					ZPlayerPrefs.SetInt ("HSEtoileW1L2", nbEtoile);
				} else if (nbEtoile <= highScoreEtoileW1L2) {
					highScoreEtoileW1L2 = highScoreEtoileW1L2;
					ZPlayerPrefs.SetInt ("HSEtoileW1L2", highScoreEtoileW1L2);
				}

				if (nbEtoile == 1) {
					uneetoile.SetActive (true);
					deuxetoiles.SetActive (false);
					troisetoiles.SetActive (false);
				} else if (nbEtoile == 2) {
					uneetoile.SetActive (false);
					deuxetoiles.SetActive (true);
					troisetoiles.SetActive (false);
				} else if (nbEtoile == 3) {
					uneetoile.SetActive (false);
					deuxetoiles.SetActive (false);
					troisetoiles.SetActive (true);
				}

			} else if (quelLevel == 3) {
				print ("Il se passe quelque chose d'autre");						// À REMPLIR UN JOUR QUAND ON AURA PLUS QUE 1 LEVEL

			}
		}


		// LES ENNEMIS
		if (other.gameObject.tag == "Ennemi" && gameObject.layer == LayerMask.NameToLayer ("Player")) {
			if (nbVie == 3) {
				ayoye = true;
				animMiniBeakyUI.SetBool ("Hurt", true);
				particlesHurt.SetActive (true);
				StartCoroutine (YoureHurt());
				anim.SetBool ("Hurt", true);
				print ("BAM! Ça fait mal...");
				nbVie--;
				animPlume3.SetBool ("Lose", true);
				animPlume2.SetBool ("Move", true);
				//StartCoroutine (YoureHurt());
				//coeur3empty.SetActive (true);
				//coeur3.SetActive (false);
			} else if (nbVie == 2) {
				ayoye = true;
				animMiniBeakyUI.SetBool ("Hurt", true);
				particlesHurt.SetActive (true);
				StartCoroutine (YoureHurt());
				anim.SetBool ("Hurt", true);
				print ("BAM! Ça fait mal...");
				nbVie--;
				animPlume2.SetBool ("Lose", true);
				animPlume1.SetBool ("Move", true);
				//StartCoroutine (YoureHurt());
				//coeur2empty.SetActive (true);
				//coeur2.SetActive (false);
			} 
			else if (nbVie <= 1) {
				animMiniBeakyUI.SetBool ("Hurt", true);								// METTRE ANIM POUR MINI BEAKY DE QUAND TU MEURS
				particlesHurt.SetActive (true);
				StartCoroutine (YouDied ());
			} 
		}


		// BONUS DE HEALTH
		if (other.gameObject.tag == "Health") {
			print ("+ 1 de vie! Yay!");
			if (nbVie == 1) {
				other.gameObject.SetActive (false);
				particlesPlume.transform.position = other.gameObject.transform.position;
				particlesPlume.SetActive (true);
				nbVie++;
				// Plume 1 arrête de bouger et plume 2 recommence à bouger
				animPlume1.SetBool ("Move", false);
				animPlume2.SetBool ("Bonus", true);
				animPlume2.SetBool ("Move", true);
				//coeur2.SetActive (true);
				//coeur2empty.SetActive (false);
			}
			else if (nbVie == 2) {
				other.gameObject.SetActive (false);
				particlesPlume.transform.position = other.gameObject.transform.position;
				particlesPlume.SetActive (true);
				nbVie++;
				// Plume 2 arrête de bouger et plume 3 recommence à bouger
				animPlume2.SetBool ("Move", false);
				animPlume3.SetBool ("Bonus", true);
				animPlume3.SetBool ("Move", true);
				//coeur3.SetActive (true);
				//coeur3empty.SetActive (false);
			}
			else if (nbVie == 3) {
				other.gameObject.SetActive (false);
				particlesPlume.transform.position = other.gameObject.transform.position;
				particlesPlume.SetActive (true);
				print ("Too bad. Déjà plein d'énergie.");
			}

		}

	}


	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "OnScreen") {
			// POUR CHANGER LA POSITION
//			gameObject.transform.position = new Vector3 (spawnBeaky.transform.position.x, gameObject.transform.position.y, 10);
//			if (Physics.CheckSphere (transform.position, sphereRadius)){
//				gameObject.transform.position = new Vector3 (spawnBeaky.transform.position.x, 3, 10);
//			}

			if (nbVie == 1) {
				StartCoroutine (YouDied ());
			} else if (nbVie == 2) {
				StartCoroutine (DeathByScreen ());
				// VIEILLE VERSION
//				StartCoroutine (YoureHurt());
//				anim.SetBool ("Hurt", true);
//				print ("BAM! Ça fait mal...");
//				nbVie--;
//				coeur2empty.SetActive (true);
//				coeur2.SetActive (false);
			} else if (nbVie == 3) {
				StartCoroutine (DeathByScreen ());
				// VIEILLE VERSION
//				StartCoroutine (YoureHurt());
//				anim.SetBool ("Hurt", true);
//				print ("BAM! Ça fait mal...");
//				nbVie--;
//				coeur3empty.SetActive (true);
//				coeur3.SetActive (false);
			}
		}
	}

//	IEnumerator CollectiblesToTarget(){
//	// ???
//	}

	IEnumerator YouDied () {
		colliderplayer.enabled = false;
		lemenupause.enabled = false;
		animPlume1.SetBool ("Lose", true);
		ayoye = true;
		//coeur1empty.SetActive (true);
		//coeur1.SetActive (false);
		movecameranewscript.enabled = false;
		//movecameranewscript.speed = 0;						// TEST
		anim.SetBool("Die", true);
		print ("Pow-pow t'es mort!");
		nbVie = 0;
		powerupscriptpremier.BeakyGotAPowerUp = false;
		powerupscriptdeuxieme.BeakyGotAPowerUp = false;
		yield return new WaitForSeconds (1);
		mainUI.SetActive (false);
		powerupUI.SetActive (false);
		dieUI.SetActive (true);
		//ayoye = false;
	}

	IEnumerator DeathByScreen(){											// LE PLAYER MEURT QUAND IL SORT DE L'ÉCRAN
		if (nbVie == 2) {
			animPlume2.SetBool ("Lose", true);
			animPlume1.SetBool ("Move", true);
			//coeur2empty.SetActive (true);
			//coeur2.SetActive (false);
			yield return new WaitForSeconds (0.5f);
			animPlume1.SetBool ("Lose", true);
			//coeur1empty.SetActive (true);
			//coeur1.SetActive (false);
			movecameranewscript.enabled = false;
			//movecameranewscript.speed = 0;					// TEST
			anim.SetBool("Die", true);
			print ("Pow-pow t'es mort!");
			nbVie = 0;
			powerupscriptpremier.BeakyGotAPowerUp = false;
			powerupscriptdeuxieme.BeakyGotAPowerUp = false;
			yield return new WaitForSeconds (1);
			mainUI.SetActive (false);
			powerupUI.SetActive (false);
			dieUI.SetActive (true);
		} else if (nbVie == 3) {
			animPlume3.SetBool ("Lose", true);
			animPlume2.SetBool ("Move", true);
			//coeur3empty.SetActive (true);
			//coeur3.SetActive (false);
			yield return new WaitForSeconds (0.5f);
			animPlume2.SetBool ("Lose", true);
			animPlume1.SetBool ("Move", true);
			//coeur2empty.SetActive (true);
			//coeur2.SetActive (false);
			yield return new WaitForSeconds (0.5f);
			animPlume1.SetBool ("Lose", true);
			//coeur1empty.SetActive (true);
			//coeur1.SetActive (false);
			movecameranewscript.enabled = false;
			anim.SetBool("Die", true);
			print ("Pow-pow t'es mort!");
			nbVie = 0;
			powerupscriptpremier.BeakyGotAPowerUp = false;
			powerupscriptdeuxieme.BeakyGotAPowerUp = false;
			yield return new WaitForSeconds (1);
			mainUI.SetActive (false);
			powerupUI.SetActive (false);
			dieUI.SetActive (true);
		}
	}


	IEnumerator YoureHurt(){
		gameObject.layer = LayerMask.NameToLayer ("Fuckall");
		//ayoye = false;
		yield return new WaitForSeconds (0.17f);
		gameObject.layer = LayerMask.NameToLayer ("Player");
		//ayoye = false;
	}

	public void Reset (){
		ZPlayerPrefs.DeleteKey ("Total");
		ZPlayerPrefs.DeleteKey ("HighScoreLTest");
	}

	void UserInputs () {
	// A  button ou Up Arrow
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetButtonDown ("360_AButton") || Input.GetKeyDown (KeyCode.W)) {
			anim.SetBool ("Fly", true);
			rbpiegon.velocity = Vector2.zero;
			rbpiegon.AddForce (new Vector2 (0, upForce));
			//print ("Je pèse sur A");
		}

	// B button
		if (Input.GetButtonDown ("360_BButton")) {
			print ("Je pèse sur : B button! (dire non au psy)");
		}
			
	// Bouton X (... 2)
		if (Input.GetButtonDown ("360_XButton")){
			print ("Je pèse sur: le bouton X! (dire oui au psy)");
		}
			

//	// Back button (... 6)
//		if (Input.GetButtonDown ("360_BackButton")){
//			print ("Je pèse sur: back button!");
//		}

	// Start button (... 7)						// MIS DANS UN AUTRE SCRIPT
//		if (Input.GetButtonDown ("360_StartButton") || Input.GetKeyDown (KeyCode.Escape)){
//			//print ("Je pèse sur: start button!");
//			if (Time.timeScale == 1) {
//				print ("Je pause le jeu");
//				Time.timeScale = 0;
//				mainUI.SetActive (false);
//				powerupUI.SetActive (false);
//				pauseUI.SetActive (true);
//			} else {
//				print ("Je remets le jeu en marche");
//				Time.timeScale == 1;
//				pauseUI.SetActive (false);
//				mainUI.SetActive (true);
//				powerupUI.SetActive (true);
//			}
//		}

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
		if (((Input.GetAxis ("360_TriggerL") > 0.001 && Input.GetAxis ("360_TriggerR") > 0.001) || Input.GetKeyDown (KeyCode.Space)) && powerupscriptpremier.BeakyGotAPowerUp == true) {
			powerupscriptpremier.BeakyGotAPowerUp = false;
			powerupscriptpremier.ActivatePowerUp ();
			print ("J'utilise le powerup #2!");

//			if (powerupscriptpremier.BeakyGotAPowerUp == true) {
//				powerupscriptpremier.BeakyGotAPowerUp = false;
//				powerupscriptpremier.ActivatePowerUp ();
//				print ("J'utilise le premier powerup!");
//			} else if (powerupscriptpremier.BeakyGotAPowerUp == false){
//				print ("Nope.");
//			}
//
//			if (powerupscriptdeuxieme.BeakyGotAPowerUp = true) {
//				powerupscriptdeuxieme.BeakyGotAPowerUp = false;
//				powerupscriptdeuxieme.ActivatePowerUp ();
//				print ("J'utilise le deuxième powerup!");
//			} else if (powerupscriptdeuxieme.BeakyGotAPowerUp == false){
//				print ("Nope.");
//			}

//		} else if (Input.GetAxis ("360_TriggerL") > 0.001 && Input.GetAxis ("360_TriggerR") < 0.001) {
//			print ("Je pèse juste sur le trigger gauche");
//		} else if (Input.GetAxis ("360_TriggerL") < 0.001 && Input.GetAxis ("360_TriggerR") > 0.001) {
//			print ("Je pèse juste sur le trigger droit");
		
		} else if (((Input.GetAxis ("360_TriggerL") > 0.001 && Input.GetAxis ("360_TriggerR") > 0.001) || Input.GetKeyDown (KeyCode.Space)) && powerupscriptdeuxieme.BeakyGotAPowerUp == true && powerupscriptpremier.BeakyGotAPowerUp == false) {
			powerupscriptdeuxieme.BeakyGotAPowerUp = false;
			powerupscriptdeuxieme.ActivatePowerUp ();
			print ("J'utilise le powerup #1!");
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
