using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public PlayerHealthManager phm;
	private PlayerStats ps;
	public GameObject go;

	// Use this for initialization
	public void NewGame () {
		SceneManager.LoadScene(startLevel, LoadSceneMode.Single);
		//SceneManager.GetActiveScene ();
		//Debug.Log ("Estou na scene: " + SceneManager.GetActiveScene ().name);
		//Debug.Log ("VOU SETAR COMO ATIVO o go");
		//Debug.Log ("Quero achar o phm");
		//go = GameObject.FindGameObjectWithTag ("Player");
		//Debug.Log ("achei o phm");
		//go.SetActive (true);

		//phm = FindObjectOfType<PlayerHealthManager> ();

		//phm.SetActivePlayer();
		//Debug.Log ("SETEI COMO ATIVO");
		//ps = FindObjectOfType<PlayerStats> ();
		//ps.currentExp = 0;
		//ps.currentLevel = 0;

		//phm.SetMaxHealth();

	}
	
	// Update is called once per frame
	public void QuitGame () {
		Debug.Log ("Game Exited");
		Application.Quit();
	}
}
