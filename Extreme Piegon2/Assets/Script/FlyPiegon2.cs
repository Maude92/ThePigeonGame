using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyPiegon2 : MonoBehaviour {

	private bool isDead = false;

	Rigidbody2D rbpiegon;
	public float upForce = 100f;
	public float maxSpeed = 5f;
	public int viePiegon = 3;
	public GameObject MasterPiegon;
	public GameObject maCamera;
	public int lettre = 0;

	public GameObject spawnPointEagle1;
	public GameObject spawnPointEagle2;


	// Use this for initialization
	void Start () {
		rbpiegon = GetComponent <Rigidbody2D> ();
		lettre = 0;
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
			StartCoroutine (DiePiegon ());
			viePiegon = 0;
		}

		print ("Nombre de vie de Mr. Piegon : " + viePiegon);
		print ("Nombre de lettres collectées: " + lettre);

	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Ennemi") {
			viePiegon--;
		}

		if (other.gameObject.tag == "Letter") {
			lettre++;
			Destroy (other.gameObject);
			//maCamera.transform.localScale = new Vector3 (-1, 1, 1);
			//spawnPointEagle1.transform.position = new Vector3 (23.21f, 2.83f, 9.974609f);
			//spawnPointEagle2.transform.position = new Vector3 (25.75f, 0.17f, 9.974609f);
			//transform.localPosition = new Vector3 (, 0, 0);
			transform.localScale = new Vector3 (-0.15f, 0.15f, 1);

		}
		//isDead = true
	}

	IEnumerator DiePiegon(){
		yield return new WaitForSeconds (2);
		MasterPiegon.SetActive (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

}
