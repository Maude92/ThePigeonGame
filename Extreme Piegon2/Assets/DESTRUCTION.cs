using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTRUCTION : MonoBehaviour {

	PowerUp powerupscript;
	public GameObject powerupsod;

	void Start(){
		powerupscript = powerupsod.GetComponent<PowerUp> ();
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Ennemi" && powerupscript.killeverybody == true) {
			Destroy (other.gameObject);
		}
			
	}
}
