using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour {

	public GameObject piegonObj;
	FlyPiegon flypiegon;

//	private AudioManager audioManager;


	// Use this for initialization
	void Start () {
		flypiegon = piegonObj.GetComponent<FlyPiegon> ();

//		audioManager = AudioManager.instance;
//		if (audioManager == null) {
//			Debug.LogError ("Attention, le audio manager n'a pas été trouvé");
//		}
	}


	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Miracle") {
			flypiegon.viePiegon++;
			Destroy (gameObject);
		}
			}

	// Update is called once per frame
	void Update () {
		
	}
}
