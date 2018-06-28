using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlyPiegon : MonoBehaviour {

	private bool isDead = false;

	Rigidbody2D rbpiegon;
	public float upForce = 100f;
	public float maxSpeed = 5f;
	public int viePiegon = 3;
	public GameObject MasterPiegon;
	public GameObject maCamera;
	public int lettre = 0;
	public int dieSound;
	public GameObject miracle;

	public GameObject spawnPointEagle1;
	public GameObject spawnPointEagle2;
	Animator anim;

	//Prendre des dommages et blinker
	public float InvicibleTime = 2;
	Collider2D[] myColls;
	public static FlyPiegon instance;


	public GameObject MedPackRetour;


	//UI
	public Text Vie3;
	public Text Vie2;
	public Text Vie1;
	public Text Vie0;

	public Text Objectif0;
	public Text Objectif1;

	// SON
	private AudioManager audioManager;


	// Use this for initialization
	void Start () {
				audioManager = AudioManager.instance;
				if (audioManager == null) {
					Debug.LogError ("Attention, le audio manager n'a pas été trouvé");
				}

		rbpiegon = GetComponent <Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		anim.SetInteger ("vie",1);
		lettre = 0;
		dieSound = 0;

		//UI
		Vie3.enabled = true;
		Vie2.enabled = false;
		Vie1.enabled = false;
		Vie0.enabled = false;

		Objectif0.enabled = true;
		Objectif1.enabled = false;


		MedPackRetour.SetActive (false);
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");

		rbpiegon.velocity = new Vector2 (h * maxSpeed, rbpiegon.velocity.y);
	}

	// Update is called once per frame
	void Update () {
		if (isDead == false) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				rbpiegon.velocity = Vector2.zero;
				rbpiegon.AddForce (new Vector2 (0, upForce));
			}
		
		}

		if (viePiegon <= 0) {
			isDead = true;
			dieSound++;
			StartCoroutine (DiePiegon ());
			viePiegon = 0;
			anim.SetInteger ("vie", 0);

			//UI
			Vie3.enabled = false;
			Vie2.enabled = false;
			Vie1.enabled = false;
			Vie0.enabled = true;
		}

		if (viePiegon == 3) {
			//UI
			Vie3.enabled = true;
			Vie2.enabled = false;
			Vie1.enabled = false;
			Vie0.enabled = false;
		}

		if (viePiegon >= 3) {
			viePiegon = 3;
		}

		if (viePiegon == 2) {
			//UI
			Vie3.enabled = false;
			Vie2.enabled = true;
			Vie1.enabled = false;
			Vie0.enabled = false;
		}

		if (viePiegon == 1) {
			//UI
			Vie3.enabled = false;
			Vie2.enabled = false;
			Vie1.enabled = true;
			Vie0.enabled = false;
		}

		print ("Nombre de vie de Mr. Piegon : " + viePiegon);
		print ("Nombre de lettres collectées: " + lettre);

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Ennemi") {
			viePiegon--;
			StartCoroutine (Blinker ());
			if (viePiegon >= 1) {
				audioManager.PlaySound ("Hurt");
			}
			//anim.
		}
			
		if (other.gameObject.tag == "Letter") {
			lettre++;
			audioManager.PlaySound ("Lettre");
			Destroy (other.gameObject);
			//maCamera.transform.localScale = new Vector3 (-1, 1, 1);
			//spawnPointEagle1.transform.position = new Vector3 (23.21f, 2.83f, 9.974609f);
			//spawnPointEagle2.transform.position = new Vector3 (25.75f, 0.17f, 9.974609f);
			//transform.localPosition = new Vector3 (, 0, 0);
			transform.localScale = new Vector3 (-0.15f, 0.15f, 1);

			//UI
			Objectif0.enabled = false;
			Objectif1.enabled = true;

			MedPackRetour.SetActive (true);

		}

		if (other.gameObject.tag == "Bullet") {
			viePiegon--;
			if (viePiegon >= 1) {
				audioManager.PlaySound ("Hurt");
			}
			StartCoroutine (Blinker ());
			StartCoroutine (ColliderMiracle ());
			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "Health") {
			audioManager.PlaySound ("Med");
		}

	}

	IEnumerator DiePiegon(){
		if (dieSound == 1) {
			audioManager.PlaySound ("Mort");
		}
		yield return new WaitForSeconds (2);
		MasterPiegon.SetActive (false);
		SceneManager.LoadScene (1);
	}

	IEnumerator ColliderMiracle() {
		miracle.SetActive (true);
		yield return new WaitForSeconds (2.5f);
		miracle.SetActive (false);
	}

//	//Blinker et Immuniter pendant un bref instant
//	void TriggerHurt () {
//		StartCoroutine (Blinker ());
//	}

	IEnumerator Blinker (){
	//Ignorer la collision avec l'ennemi
		GetComponent<Collider2D> ().enabled = false;
		anim.SetLayerWeight (1,1);
		yield return new WaitForSeconds (InvicibleTime);
		GetComponent<Collider2D> ().enabled = true;
		anim.SetLayerWeight (1, 0);

		print ("Je fonctionne, mais je bug comme une merde");

//		int EnemyLayer = LayerMask.NameToLayer ("Ennemi");
//		int PlayerLayer = LayerMask.NameToLayer ("Player");
//		Physics2D.IgnoreLayerCollision (EnemyLayer, PlayerLayer);
	}

}
