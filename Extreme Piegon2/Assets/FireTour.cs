﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTour : MonoBehaviour {

	public GameObject Spawnpoint;
	public GameObject Bullet;

	public int BulletSpeed = 10;
	public float timebeforedestroy = 3f;

	//bool HorsdePortee = true;

	//bool hasCoroutineStarted = false; 

	// Use this for initialization
	void Start () {
		StartCoroutine (Fire ());
	}


	// Update is called once per frame
	void Update () {
		//transform.LookAt(target);


	}

	IEnumerator Fire(){
		while (true) {
			print ("FIRE !!!");
			GameObject projectile;
			projectile = (GameObject)Instantiate (Bullet, Spawnpoint.transform.position, Quaternion.identity);
			Rigidbody2D rb;
			rb = projectile.GetComponent<Rigidbody2D> ();
			rb.AddForce (transform.right * BulletSpeed);
			//HorsdePortee = false;
			Destroy (projectile, timebeforedestroy);
			yield return new WaitForSeconds (0.3f);

			projectile = (GameObject)Instantiate (Bullet, Spawnpoint.transform.position, Quaternion.identity);
			//Rigidbody2D rb;
			rb = projectile.GetComponent<Rigidbody2D> ();
			rb.AddForce (transform.right * BulletSpeed);
			Destroy (projectile, timebeforedestroy);
			yield return new WaitForSeconds (0.35f);

			projectile = (GameObject)Instantiate (Bullet, Spawnpoint.transform.position, Quaternion.identity);
			//Rigidbody2D rb;
			rb = projectile.GetComponent<Rigidbody2D> ();
			rb.AddForce (transform.right * BulletSpeed);
			Destroy (projectile, timebeforedestroy);
			yield return new WaitForSeconds (2);


			//Pour le Zepplin juste mettre ça à un delais très court pour qu'il arrête pas d'en tirer.
			//Zepplin = mélange code LookAtandFire + les Ailges
		}
	}
}
