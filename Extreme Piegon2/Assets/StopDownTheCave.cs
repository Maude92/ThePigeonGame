using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopDownTheCave : MonoBehaviour {

	public GameObject laCamera;

	MoveCameraNEW movecamerascript;

	// Use this for initialization
	void Start () {
		movecamerascript = laCamera.GetComponent<MoveCameraNEW> ();
	}
	
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			movecamerascript.downTheCave = false;
		}
	}
}
