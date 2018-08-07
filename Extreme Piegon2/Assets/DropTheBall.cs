using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTheBall : MonoBehaviour {

	//public GameObject petiteRoche;
	public GameObject normaleRoche;
	//public GameObject grosseRoche;

	//Rigidbody2D rbPetit;
	Rigidbody2D rbNormal;
	//Rigidbody2D rbGros;

	// Use this for initialization
	void Start () {
		//rbPetit = petiteRoche.GetComponent<Rigidbody2D> ();
		rbNormal = normaleRoche.GetComponent<Rigidbody2D> ();
		//rbGros = grosseRoche.GetComponent<Rigidbody2D> ();

		//rbPetit.isKinematic = true;
		rbNormal.isKinematic = true;
		//rbGros.isKinematic = true;
	}
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			rbNormal.isKinematic = false;
		}
	}
}
