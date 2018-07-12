using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicDommage : MonoBehaviour {

	public GameObject[] ImgDammage;
	int NumberOfImages;

	//Changer le != "Player" par un Tag Décor pour les éléments du décor"
	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag != "Player") {
			NumberOfImages = Random.Range (1, 4);
			DammageCheck ();
		}
			
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Ennemi") {
			NumberOfImages = Random.Range (1, 4);
			DammageCheck ();
		}
	}

	public void DammageCheck (){
		if (NumberOfImages == 1) {
			ImgDammage [0].SetActive (true);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (false);
		}

		if (NumberOfImages == 2){
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (true);
			ImgDammage [2].SetActive (false);
		}

		if (NumberOfImages == 3) {
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (true);
		}
	}
}
