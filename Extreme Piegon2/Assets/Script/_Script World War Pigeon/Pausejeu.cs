using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pausejeu : MonoBehaviour {

	public GameObject pauseUI;
	public GameObject mainUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				mainUI.SetActive (false);
				pauseUI.SetActive (true);
			} else {
				Time.timeScale = 1;
				pauseUI.SetActive (false);
				mainUI.SetActive (true);
		}
	}
}
}
