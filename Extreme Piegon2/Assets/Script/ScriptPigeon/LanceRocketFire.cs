using UnityEngine;
using System.Collections;

public class LanceRocketFire : MonoBehaviour {

	public Transform Target;

	//private Coroutine gameCoroutine = true;

	public GameObject Spawnpoint;
	public GameObject Bullet;

	//public Collider2D ZoneStop;

	public int BulletSpeed = 1;
	public float timebeforedestroy = 3f;

	// Use this for initialization
	void Start () {
		StartCoroutine (Fire ());
	}
	
	// Update is called once per frame
	void Update () {
//		Quaternion rotation = Quaternion.LookRotation
//			(Target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
//		transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}

	public IEnumerator Fire(){
		while (true) {
			print ("FIRE !!!");
			GameObject projectile;
			projectile = (GameObject)Instantiate (Bullet, Spawnpoint.transform.position, Quaternion.identity);
			Rigidbody2D rb;
			rb = projectile.GetComponent<Rigidbody2D> ();
			rb.AddForce (transform.up * BulletSpeed);
			Destroy (projectile, timebeforedestroy);
			yield return new WaitForSeconds (8f);
		}
}

	public void StoplaRoutine (){
			StopCoroutine (Fire());
	}

//	void OnTriggerEnter2D (Collider2D other){
//		if (other.gameObject.tag == "Player") {
//			StopCoroutine (Fire ());
//		}
//	}

}
