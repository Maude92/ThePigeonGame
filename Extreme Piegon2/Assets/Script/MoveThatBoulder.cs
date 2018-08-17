using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThatBoulder : MonoBehaviour {

	public float boulderspeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.gameObject.tag == "Boulder") {
			print ("La roche touche le sol!");
			Rigidbody2D rbboulder;
			rbboulder = other.GetComponent<Rigidbody2D> ();
			rbboulder.AddForce (new Vector2 (boulderspeed, 0));
		}
	}
}
