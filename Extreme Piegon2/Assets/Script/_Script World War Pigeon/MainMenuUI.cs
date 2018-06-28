using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

	public GameObject mainmenuUI;
	public GameObject instructionsUI;
	public GameObject creditsUI;
	public GameObject controlescontainer;
	public GameObject ennemiscontainer;
	public GameObject objetscontainer;

	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		audioManager = AudioManager.instance;
		if (audioManager == null) {
			Debug.LogError ("Attention, le AudioManager n'a pas été trouvé dans la scène.");}
	}

	// QUITTER LE JEU
	public void Quit() {
		print ("Bye bye!");
		Application.Quit ();
	}

	// PASSER AU PROCHAIN NIVEAU / COMMENCER LE JEU
	public void NextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	// JOUER UN SON QUAND JE CLIQUE
	public void playClip () {
		audioManager.PlaySound ("Clic");
	}

	// POUR ALLER AUX INSTRUCTIONS
	public void Instructions () {
		mainmenuUI.SetActive (false);
		instructionsUI.SetActive (true);
	}

	// POUR RETOURNER AU MENU PRINCIPAL, FROM INSTRUCTIONS
	public void RetourI () {
		instructionsUI.SetActive (false);
		mainmenuUI.SetActive (true);
	}

	// POUR ALLER AUX CREDITS
	public void Credits () {
		mainmenuUI.SetActive (false);
		creditsUI.SetActive (true);
	}

	// POUR RETOURNER AU MENU PRINCIPAL, FROM CREDITS
	public void RetourC () {
		creditsUI.SetActive (false);
		mainmenuUI.SetActive (true);
	}

	// POUR AFFICHER LES CONTRÔLES
	public void AfficheControles (){
		ennemiscontainer.SetActive (false);
		objetscontainer.SetActive (false);
		controlescontainer.SetActive (true);
	}

	// POUR AFFICHER LES ENNEMIS
	public void AfficheEnnemis () {
		controlescontainer.SetActive (false);
		objetscontainer.SetActive (false);
		ennemiscontainer.SetActive (true);
	}

	// POUR AFFICHER LES OBJETS À COLLECTER
	public void AfficheObjets () {
		controlescontainer.SetActive (false);
		ennemiscontainer.SetActive (false);
		objetscontainer.SetActive (true);
	}
}
