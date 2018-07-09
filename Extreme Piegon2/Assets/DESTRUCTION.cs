using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DESTRUCTION : MonoBehaviour {


	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Ennemi") {
			Destroy (gameObject);
		}
			
	}
}
