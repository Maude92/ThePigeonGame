using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealt4 : MonoBehaviour {

	public GameObject healthPack4;


	public int countHealth;

	// Use this for initialization
	void Start () {
		countHealth = 0;
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Miracle") && countHealth == 0) {
			healthPack4.SetActive (true);
			countHealth++;
			GetComponent<Collider2D> ().enabled = false;
		}
	}
}
