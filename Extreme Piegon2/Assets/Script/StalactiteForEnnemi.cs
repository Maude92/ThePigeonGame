using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteForEnnemi : MonoBehaviour {

	bool destroyNow;
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Ennemi") {
			Collider2D ennemiCol;
			ennemiCol = other.gameObject.GetComponent<Collider2D> ();
			ennemiCol.enabled = false;
			Animator anim;
			anim = other.gameObject.GetComponent<Animator> ();
			anim.SetBool ("Die", true);
//			StartCoroutine (ExplodingBird ());
//			if (destroyNow == true) {
//				Destroy (other.gameObject);
//				destroyNow = false;
//			}
		}
	}

	IEnumerator ExplodingBird (){
		yield return new WaitForSeconds (0.2f);
		destroyNow = true;
	}
}
