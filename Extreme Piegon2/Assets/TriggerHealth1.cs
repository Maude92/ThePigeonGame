using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealth1 : MonoBehaviour {

	public GameObject healthPack1;


	public int countHealth;

	// Use this for initialization
	void Start () {
		countHealth = 0;
	}
	

	void OnTriggerEnter2D (Collider2D other)
	{
		if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Miracle") && countHealth == 0) {
			healthPack1.SetActive (true);
			countHealth++;
			GetComponent<Collider2D> ().enabled = false;
		}
	}
}
