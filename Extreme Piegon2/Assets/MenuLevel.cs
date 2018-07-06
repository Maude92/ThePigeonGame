using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour {


	public void TryAgain (){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
