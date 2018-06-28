using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiLevel1 : MonoBehaviour {

	public GameObject pauseUI;
	public GameObject player;

	private AudioManager audioManager;

	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention, le AudioManager n'a pas été trouvé dans la scène.");}
	}

	public void Quit() {
		print ("Bye bye!");
		Application.Quit ();
	}

	public void NextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void MainMenu() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

	public void MainMenuFromLevel2() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2);
	}

	public void playClip(){
		audioManager.PlaySound ("Clic");
	}

	public void Retry() {
		print ("C'est trop le fun, on recommence!");
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void ContinueFromPause(){
		pauseUI.SetActive (false);
		player.SetActive (true);
	}
}
