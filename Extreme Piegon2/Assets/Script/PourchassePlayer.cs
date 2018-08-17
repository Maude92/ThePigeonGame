using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourchassePlayer : MonoBehaviour {


	//public GameObject normaleRoche;
	public GameObject parentRoche;
	//public float speedRoche;
	//bool translationRoche;


	Rigidbody2D rbNormal;
	Animator anim;


	// Use this for initialization
	void Start () {
		rbNormal = GetComponent<Rigidbody2D> ();
		anim = parentRoche.GetComponent<Animator> ();
	}

//	void Update(){
//		if (translationRoche == true) {
//			transform.Translate (Vector3.right * speedRoche * Time.deltaTime);
//		}
//	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Plancher") {
			//rbNormal.isKinematic = true;
			//transform.parent = other.transform;
			//anim.SetBool ("Ground", true);
			//translationRoche = true;
			rbNormal.constraints = RigidbodyConstraints2D.FreezePositionX;
			anim.SetLayerWeight (1, 1);
			anim.SetBool ("Ground", true);
		}
	}
}
