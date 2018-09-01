using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopThatRoche : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Boulder") {
			Animator anim;
			anim = other.GetComponentInParent<Animator> ();
			anim.SetBool ("Stop", true);
			//anim.SetLayerWeight (1, 0);
			other.transform.parent = gameObject.transform;
		}
	}
}
