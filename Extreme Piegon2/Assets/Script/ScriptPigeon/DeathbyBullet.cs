using UnityEngine;
using System.Collections;

public class DeathbyBullet : MonoBehaviour {

	public GameObject piegonObj;
	FlyPiegon flypiegon;

	// Use this for initialization
	void Start () {
		flypiegon = piegonObj.GetComponent<FlyPiegon> ();
	}
	
	// Update is called once per frame
	void Update () {
	


	}


	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	} 
}
