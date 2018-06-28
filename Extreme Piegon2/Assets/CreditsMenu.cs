using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour {

	public GameObject mainUI;
	public GameObject creditsUI;
	public GameObject instructionsUI;


	public void ReturntoMenuFromCreditse () {
		creditsUI.SetActive (false);
		instructionsUI.SetActive (false);
		mainUI.SetActive (true);
	}

	public void ReturntoMenuFromInstructions () {
		instructionsUI.SetActive (false);
		mainUI.SetActive (true);
	}


}
