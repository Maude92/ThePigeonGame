using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {

	public GameObject mainUI;
	public GameObject pauseUI;

	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention, erreur audio manager pas trouvé");
		}
	}
	
	public void Quit () {
		print ("Bye!");
		Application.Quit();
	}

	public void GoBackToMainMenu() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

	public void Continue () {
		pauseUI.SetActive (false);
		mainUI.SetActive (true);
		Time.timeScale = 1;
	}

	public void playCLip () {
		audioManager.PlaySound ("Clic");
	}
}
