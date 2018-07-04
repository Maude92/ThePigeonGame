using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicDommage : MonoBehaviour {

	public GameObject[] ImgDammage;
	int n;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag != "Player") {
			n = Random.Range (1, 4);
			DammageCheck ();
		}
			
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag != "Player") {
			n = Random.Range (1, 4);
			DammageCheck ();
		}
	}

	public void DammageCheck (){
		if (n == 1) {
			ImgDammage [0].SetActive (true);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (false);
		}

		if (n == 2){
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (true);
			ImgDammage [2].SetActive (false);
		}

		if (n == 3) {
			ImgDammage [0].SetActive (false);
			ImgDammage [1].SetActive (false);
			ImgDammage [2].SetActive (true);
		}
	}
}
