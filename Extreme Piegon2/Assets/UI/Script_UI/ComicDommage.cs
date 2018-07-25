using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicDommage : MonoBehaviour {

	public GameObject[] ImgDammage;
	int NumberOfImages;

	//Changer le != "Player" par un Tag Décor pour les éléments du décor"
//	void OnCollisionEnter2D (Collision2D col){					// À REMETTRE SI LES ÉLÉMENTS DU DÉCOR FONT APPARAÎTRE CA AUSSI
//		if (col.gameObject.tag != "Player") {
//			NumberOfImages = Random.Range (1, 8);
//			DammageCheck ();
//		}
//	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Ennemi") {
			NumberOfImages = Random.Range (1, 8);
			DammageCheck ();
		}
	}

	public void DammageCheck (){
		if (NumberOfImages == 1) {
			ImgDammage [0].SetActive (true);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (false);
			ImgDammage [3].SetActive (false);
			ImgDammage [4].SetActive (false);
			ImgDammage [5].SetActive (false);
			ImgDammage [6].SetActive (false);
		}

		if (NumberOfImages == 2){
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (true);
			ImgDammage [2].SetActive (false);
			ImgDammage [3].SetActive (false);
			ImgDammage [4].SetActive (false);
			ImgDammage [5].SetActive (false);
			ImgDammage [6].SetActive (false);
		}

		if (NumberOfImages == 3) {
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (true);
			ImgDammage [3].SetActive (false);
			ImgDammage [4].SetActive (false);
			ImgDammage [5].SetActive (false);
			ImgDammage [6].SetActive (false);
		}

		if (NumberOfImages == 4) {
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (false);
			ImgDammage [3].SetActive (true);
			ImgDammage [4].SetActive (false);
			ImgDammage [5].SetActive (false);
			ImgDammage [6].SetActive (false);
		}

		if (NumberOfImages == 5) {
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (false);
			ImgDammage [3].SetActive (false);
			ImgDammage [4].SetActive (true);
			ImgDammage [5].SetActive (false);
			ImgDammage [6].SetActive (false);
		}

		if (NumberOfImages == 6) {
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (false);
			ImgDammage [3].SetActive (false);
			ImgDammage [4].SetActive (false);
			ImgDammage [5].SetActive (true);
			ImgDammage [6].SetActive (false);
		}

		if (NumberOfImages == 7) {
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (false);
			ImgDammage [3].SetActive (false);
			ImgDammage [4].SetActive (false);
			ImgDammage [5].SetActive (false);
			ImgDammage [6].SetActive (true);
		}
	}
}
