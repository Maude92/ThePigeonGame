using UnityEngine;
using System.Collections;

public class FollowBullet : MonoBehaviour {

	Transform target;
	public float speed = .01f;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {


		target = GameObject.FindWithTag ("Player").transform;

		Vector3 forwardAxis = new Vector3 (target.transform.position.x, target.transform.position.y, -1);




		transform.LookAt (target.position, forwardAxis);
		Debug.DrawLine (transform.position, target.position);
		transform.eulerAngles = new Vector3 (0, 0, -transform.eulerAngles.z);
		transform.position -= transform.TransformDirection (Vector2.up) * speed ;
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	} 
}
