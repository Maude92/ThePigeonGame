using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraNEW : MonoBehaviour {

	public float speed;
	public GameObject player;

	SauvegardeTest sauvegardetest;

	// Use this for initialization
	void Start () {
		sauvegardetest = player.GetComponent<SauvegardeTest> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
