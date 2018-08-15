using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoFaster : MonoBehaviour {

	public GameObject laCamera;
	public float newSpeed = 4.5f;
	public float newDownSpeed = 1.75f;

	MoveCameraNEW movecameranewscript;


	void Start (){
		movecameranewscript = laCamera.GetComponent <MoveCameraNEW> ();
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			movecameranewscript.speed = newSpeed;
		//	movecameranewscript.downSpeed = newDownSpeed;
		}
	}

	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			movecameranewscript.speed = 2.5f;
		//	movecameranewscript.downSpeed = 0.25f;
		}
	}
}
