using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	// Use this for initialization
	public void NewGame () {
		SceneManager.LoadScene(startLevel);
	}
	
	// Update is called once per frame
	public void QuitGame () {
		Debug.Log ("Game Exited");
		Application.Quit();
	}
}
