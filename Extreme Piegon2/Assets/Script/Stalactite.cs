using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour {

	public GameObject boutQuiTombe;

	Rigidbody2D rbStalactite;
	Collider2D colStalactite;

	// Use this for initialization
	void Start () {
		rbStalactite = boutQuiTombe.GetComponent<Rigidbody2D> ();
		colStalactite = boutQuiTombe.GetComponent<EdgeCollider2D> ();

		rbStalactite.isKinematic = true;
	}
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			rbStalactite.isKinematic = false;
			boutQuiTombe.gameObject.tag = "Ennemi";
			colStalactite.enabled = false;
		}
	}
}
