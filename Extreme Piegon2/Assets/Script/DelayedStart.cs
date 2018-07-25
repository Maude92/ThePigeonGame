using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStart : MonoBehaviour {

	//public GameObject countdown;
	//Animator anim;

	public GameObject countdown3;
	public GameObject countdown2;
	public GameObject countdown1;
	public GameObject countdownGo;

	SauvegardeTest sauvegardetest;
	MenuPause menupausescript;
	public GameObject player;

	// Use this for initialization
	void Start () {
		sauvegardetest = player.GetComponent<SauvegardeTest> ();
		menupausescript = player.GetComponent<MenuPause> ();

		StartCoroutine (StartDelay());

		//anim = countdown.GetComponent<Animator> ();
	}

	IEnumerator StartDelay(){
//		Ma version qui marche pas
//		yield return new WaitForSeconds (3f);
//		if (anim.GetBool ("Fin") == true) {
//			print ("Fuck off");
//			countdown.SetActive (false);
//		}

		// L'autre version de youtube
//		Time.timeScale = 0;
//		float pauseTime = Time.realtimeSinceStartup + 3f;
//		while (Time.realtimeSinceStartup < pauseTime)
//			yield return 0;
//		//countdown.SetActive (false);
//		Time.timeScale = 1;

		// Un autre test
		sauvegardetest.enabled = false;
		menupausescript.enabled = false;
		Time.timeScale = 0;
		countdown3.SetActive (true);
		yield return new WaitForSecondsRealtime (1f);
		countdown3.SetActive (false);
		countdown2.SetActive (true);
		yield return new WaitForSecondsRealtime (1f);
		countdown2.SetActive (false);
		countdown1.SetActive (true);
		yield return new WaitForSecondsRealtime (1f);
		countdown1.SetActive (false);
		countdownGo.SetActive (true);
		yield return new WaitForSecondsRealtime (0.5f);
		countdownGo.SetActive (false);
		Time.timeScale = 1;
		sauvegardetest.enabled = true;
		menupausescript.enabled = true;
	}

}
