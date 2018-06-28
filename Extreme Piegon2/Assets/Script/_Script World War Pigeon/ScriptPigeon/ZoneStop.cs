using UnityEngine;
using System.Collections;

public class ZoneStop : MonoBehaviour {

	public LanceRocketFire LanceRocketScript;
	public GameObject Rocket;

	// Use this for initialization
	void Start () {
		LanceRocketScript = gameObject.GetComponentInParent<LanceRocketFire> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.tag == "Player") {
			//LanceRocketScript.StoplaRoutine ();
			Rocket.SetActive(false);
		}
	}
}
