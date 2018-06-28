using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victoire : MonoBehaviour {
	FlyPiegon fp;

	public GameObject Piedgon;

	//SON

	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		fp = Piedgon.GetComponent<FlyPiegon> ();

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention, le audio manager n'a pas été trouvé");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D chose){
		if (fp.lettre > 0) {
			audioManager.PlaySound ("Victoire");
			SceneManager.LoadScene (2);
		}
	}


 
}
