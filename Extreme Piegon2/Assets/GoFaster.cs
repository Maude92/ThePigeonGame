using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFaster : MonoBehaviour {

	public GameObject laCamera;
	public float newSpeed = 3f;

	MoveCameraNEW movecameranewscript;


	void Start (){
		movecameranewscript = laCamera.GetComponent <MoveCameraNEW> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			movecameranewscript.speed = newSpeed;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			movecameranewscript.speed = 2.5f;
		}
	}
}
