using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public GameObject piegonObj;
	FlyPiegon flypiegon;

	public float speed;

//	public GameObject spawnPointEagle1;
//	public GameObject spawnPointEagle2;

	void Start () {
		flypiegon = piegonObj.GetComponent<FlyPiegon> ();
	}

	void Update() {
		if (flypiegon.lettre == 0) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		} else if (flypiegon.lettre == 1) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
//			spawnPointEagle1.transform.position = new Vector3 (-10.21f, 2.83f, 9.974609f);
//			spawnPointEagle2.transform.position = new Vector3 (-11.75f, 0.17f, 9.974609f);
		}
	}
		
}
