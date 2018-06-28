using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHealth : MonoBehaviour {

	public GameObject healthPack1;
	public GameObject healthPack2;
	public GameObject healthPack3;
	public GameObject healthPack4;
	public GameObject healthPack5;
	public GameObject healthPack6;

	public int countHealth;

	// Use this for initialization
	void Start () {
		countHealth = 0;
	}

	void OnTriggerEnter2D (Collider2D other){
		if ((other.gameObject.tag == "Player" || other.gameObject.tag =="Miracle") && countHealth == 0) {
			healthPack1.SetActive (true);
			countHealth++;
			GetComponent<Collider2D> ().enabled = false;
		} else if ((other.gameObject.tag == "Player" || other.gameObject.tag =="Miracle") && countHealth == 1) {
			healthPack2.SetActive (true);
			countHealth++;
			GetComponent<Collider2D> ().enabled = false;
		} else if ((other.gameObject.tag == "Player" || other.gameObject.tag =="Miracle") && countHealth == 2) {
			healthPack3.SetActive (true);
			countHealth++;
			GetComponent<Collider2D> ().enabled = false;
		} else if ((other.gameObject.tag == "Player" || other.gameObject.tag =="Miracle") && countHealth == 3) {
			healthPack4.SetActive (true);
			countHealth++;
			GetComponent<Collider2D> ().enabled = false;
		} else if ((other.gameObject.tag == "Player" || other.gameObject.tag =="Miracle") && countHealth == 4) {
			healthPack5.SetActive (true);
			countHealth++;
			GetComponent<Collider2D> ().enabled = false;
		} else if ((other.gameObject.tag == "Player" || other.gameObject.tag =="Miracle") && countHealth == 5) {
			healthPack6.SetActive (true);
			countHealth++;GetComponent<Collider2D> ().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
