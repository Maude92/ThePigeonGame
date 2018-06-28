using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RespawnSquirrel : MonoBehaviour {

	public GameObject lifepointObj;

	LifePoints lifepointsscript;

	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		lifepointsscript = lifepointObj.GetComponent<LifePoints> ();

		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention, le AudioManager n'a pas été trouvé dans la scène.");}
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < -5) {
			audioManager.PlaySound ("Die");
			lifepointsscript.lifepoints = 0;
			SceneManager.LoadScene (1);	

		}

	}
}
