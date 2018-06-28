using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEagle2 : MonoBehaviour {

	public GameObject spawnpoint;		// aka bout canon
	public GameObject evileagleprefab;
	public int speedeagle = 500;
	public float timebeforedestroy = 5f;

	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		StartCoroutine (AttackPlayer ());

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention, le audio manager n'a pas été trouvé");
		}
	}

	IEnumerator AttackPlayer(){
		while (true) {
			yield return new WaitForSeconds (13);
			Debug.Log ("Eagle incoming!!");
			GameObject projectile;
			projectile = (GameObject)Instantiate (evileagleprefab, spawnpoint.transform.position, Quaternion.identity);
			Rigidbody2D rb;
			rb = projectile.GetComponent<Rigidbody2D> ();
			rb.AddForce (-transform.right * speedeagle);
			audioManager.PlaySound ("Eagle");
			Destroy (projectile, timebeforedestroy);
			//yield return new WaitForSeconds (8);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
