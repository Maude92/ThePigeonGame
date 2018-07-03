using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Psy : MonoBehaviour {

	public float Timer = 10f;
	public bool InterfacePsyIsHere = false;

	public GameObject Psy_UI;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = Psy_UI.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			print ("UI du psy montre toi !");
			anim.SetBool ("Apparition", true);
			anim.SetBool ("Disparition", false);
			InterfacePsyIsHere = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		CheckTimerForPsy ();
	}

	public void CheckTimerForPsy () {
		if (InterfacePsyIsHere == true) {
			Timer = Timer- 1 * Time.deltaTime;
		}

		if (Timer <= 0) {
			anim.SetBool ("Disparition", true);
			anim.SetBool ("Apparition", false);
		}
	}
}
