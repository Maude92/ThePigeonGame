using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : MonoBehaviour {

	public Transform target;
	public bool moveToTarget;
	public float speedToTarget;

	float step;

	Animator anim;

	GoToTarget gototargetscript;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();

		step = speedToTarget * Time.deltaTime;

		moveToTarget = false;

		gototargetscript = GetComponent<GoToTarget> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (moveToTarget == true) {
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);
			print ("Je bouge jusqu'au target.");
			if (transform.position == target.position) {
				StartCoroutine (DoneMoving ());
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player" && gameObject.layer == LayerMask.NameToLayer ("Powerup")) {
			StartCoroutine (PowerupJuice ());
		} else if (other.gameObject.tag == "Player" && gameObject.layer == LayerMask.NameToLayer("Berry")) {
			StartCoroutine (BerryJuice ());
		}
	}

	IEnumerator BerryJuice(){
		anim.SetBool ("Miam", true);
		moveToTarget = true;
		yield return new WaitForSeconds (1);
		gameObject.SetActive (false);
		//Destroy (gameObject);
	}

	IEnumerator PowerupJuice(){
		anim.SetBool ("Miam", true);
		moveToTarget = true;
		yield return new WaitForSeconds (1);
	}

	IEnumerator DoneMoving (){
		print ("J'ai fini.");
		yield return new WaitForSeconds (3);
		moveToTarget = false;
		gototargetscript.enabled = false;
	}
}
