using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceBouleFeu : MonoBehaviour {

	public GameObject frontcheckE2;		// aka bout canon
	public GameObject bouledefeu;		// aka balle
	public int forcebouledefeu = 500;
	public float timebeforedestroy = 1.3f;

	// Use this for initialization
	void Start () {
		StartCoroutine (AttackPlayer ());
	}

	IEnumerator AttackPlayer(){
		while (true) {
			Debug.Log ("Evil monstre lance une boule de feu.");
			GameObject projectile;
			projectile = (GameObject)Instantiate (bouledefeu, frontcheckE2.transform.position, Quaternion.identity);
			Rigidbody2D rb;
			rb = projectile.GetComponent<Rigidbody2D> ();
			rb.AddForce (-transform.right * forcebouledefeu);
			Destroy (projectile, timebeforedestroy);
			yield return new WaitForSeconds (2);
		}
	}

//	void OnTriggerStay2D (Collider2D other){
//		if (other.gameObject.tag == "Player") {
//			GameObject projectile;
//			projectile = (GameObject)Instantiate (bouledefeu, frontcheckE2.transform.position, Quaternion.identity);
//			Destroy (projectile);
//		}
//	}

}
