using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsMenuPigeon : MonoBehaviour {
	public AudioClip audioClick;
	AudioSource audio;
	public int BoutonStartOver = 1;
	public int BoutonMenu = 0;

	public GameObject mainUI;
	public GameObject creditsUI;
	public GameObject instructionsUI;


	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	public void Button_Click_StartOver(){
		audio.clip = audioClick;
		audio.Play();
		StartCoroutine (DelaySceneLoad (BoutonStartOver));
	}

	public void GoToCredits () {
		mainUI.SetActive (false);
		creditsUI.SetActive (true);
	}

	public void GoToInstructions() {
		mainUI.SetActive (false);
		instructionsUI.SetActive (true);
	}

	public void StartGame() {
//		audio.clip = audioClick;
//		audio.Play ();
//		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void Button_Click_Menu(){
		audio.clip = audioClick;
		audio.Play();
		StartCoroutine (DelaySceneLoad (BoutonMenu));
	}
	public void Button_Click_Instructions(){
		audio.clip = audioClick;
		audio.Play();
		StartCoroutine (DelaySceneLoad (5));
	}


	public void Button_Click_Exit(){
		audio.clip = audioClick;
		audio.Play();
		StartCoroutine (DelaySceneQuit ());
	}


	IEnumerator DelaySceneLoad(int SceneNumber){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene (SceneNumber);
	}

	IEnumerator DelaySceneQuit(){
		yield return new WaitForSeconds (0.3f);
		Application.Quit();
	}



	// Update is called once per frame
	void Update () {
		
	}
}
