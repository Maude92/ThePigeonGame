using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuLevel : MonoBehaviour {

	public GameObject loadingScreen;
	public GameObject player;

	public Slider slider;
	public Text progressText;
	public Text[] randomFact;
	public Text randomFactText;

	MenuPause lemenupause;
	SauvegardeTest playerscript;

	public GameObject pauseUI;
	public GameObject mainUI;
	public GameObject powerupUI;
	public GameObject playerUI;
	public GameObject psygeonUI;
	public GameObject imagePsygeonUI;


	void Start (){
		lemenupause = player.GetComponent<MenuPause> ();
		playerscript = player.GetComponent<SauvegardeTest> ();
	}

		
	public void TryAgain (){
		if (lemenupause.modePause == true) {
			lemenupause.modePause = false;
		}
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void NextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void MainMenu(){
		SceneManager.LoadScene (0);
	}

	public void ResumeGame(){
		lemenupause.modePause = !lemenupause.modePause;
		print ("Je remets le jeu en marche");
		Time.timeScale = 1;
		pauseUI.SetActive (false);
		mainUI.SetActive (true);
		playerUI.SetActive (true);
		psygeonUI.SetActive (true);
		imagePsygeonUI.SetActive (true);
		powerupUI.SetActive (true);
		playerscript.enabled = true;
	}

	public void QuitGame(){
		print ("Bye bye");
		Application.Quit ();
	}

		



	// VERSION SI ON VEUT AJOUTER LE LOADING SCREEN

	public void TryAgainLoad(){
		if (lemenupause.modePause == true) {
			lemenupause.modePause = false;
		}
		Time.timeScale = 1;

	// POUR AFFICHER LES RANDOM FACTS.... DE MANIÈRE RANDOM
		int indexRandomFact = Random.Range (0, randomFact.Length);
		randomFactText.text = randomFact [indexRandomFact].text;

		StartCoroutine (LoadAsyncThis ());
	}

	public void NextLevelLoad(){
		int indexRandomFact = Random.Range (0, randomFact.Length);
		randomFactText.text = randomFact [indexRandomFact].text;

		StartCoroutine (LoadAsyncNext ());
	}

	public void MainMenuLoad (){
		int indexRandomFact = Random.Range (0, randomFact.Length);
		randomFactText.text = randomFact [indexRandomFact].text;

		StartCoroutine (LoadAsyncMainMenu ());
	}




	// LES COROUTINES

	IEnumerator LoadAsyncThis (){
		AsyncOperation operation = SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
		loadingScreen.SetActive (true);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			slider.value = progress;
			progressText.text = (progress * 100f).ToString("F0") + "%";
			yield return null;
		}
	}

	IEnumerator LoadAsyncNext (){
		AsyncOperation operation = SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex + 1);
		loadingScreen.SetActive (true);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			slider.value = progress;
			progressText.text = (progress * 100f).ToString("F0") + "%";
			yield return null;
		}
	}

	IEnumerator LoadAsyncMainMenu (){
		AsyncOperation operation = SceneManager.LoadSceneAsync (0);
		loadingScreen.SetActive (true);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			slider.value = progress;
			progressText.text = (progress * 100f).ToString("F0") + "%";
			yield return null;
		}
	}


}
