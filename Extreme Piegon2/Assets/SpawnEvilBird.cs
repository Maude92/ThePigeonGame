using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEvilBird : MonoBehaviour {

	public GameObject spawnpoint;
	public GameObject evilbirdprefab;
	public int speedbird = 500;
	public float timebeforedestroy = 5f;

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			print ("Evil bird on the way!");
			StartCoroutine (AttackPlayer ());
		}
	}

	IEnumerator AttackPlayer(){
		yield return new WaitForSeconds (0.1f);
		GameObject evilbird;
		evilbird = (GameObject)Instantiate (evilbirdprefab, spawnpoint.transform.position, Quaternion.identity);
		Rigidbody2D rb;
		rb = evilbird.GetComponent<Rigidbody2D> ();
		rb.AddForce (-transform.right * speedbird);
		Destroy (evilbird, timebeforedestroy);
	}


	// OLD VERSION
//	IEnumerator AttackPlayer(){
//		while (true) {
//			yield return new WaitForSeconds (8);
//			Debug.Log ("Eagle incoming!!");
//			GameObject projectile;
//			projectile = (GameObject)Instantiate (evileagleprefab, spawnpoint.transform.position, Quaternion.identity);
//			Rigidbody2D rb;
//			rb = projectile.GetComponent<Rigidbody2D> ();
//			rb.AddForce (-transform.right * speedeagle);
//			audioManager.PlaySound ("Eagle");
//			Destroy (projectile, timebeforedestroy);
//		}
//	}
}
