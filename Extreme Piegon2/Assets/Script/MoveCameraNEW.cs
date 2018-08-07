using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraNEW : MonoBehaviour {

	public float speed;
	public GameObject player;
	public bool downTheCave;
	public float downSpeed;

	SauvegardeTest sauvegardetest;

	// Use this for initialization
	void Start () {
		sauvegardetest = player.GetComponent<SauvegardeTest> ();

		downTheCave = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (downTheCave == false) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		} else if (downTheCave == true) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			transform.Translate (Vector3.down * downSpeed * Time.deltaTime);
		}
	}
}
