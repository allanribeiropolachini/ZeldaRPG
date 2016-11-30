using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

	public string levelToLoad;

	public string exitPoint;

	public static PlayerController thePlayer;

	public static bool startexist;

	// Use this for initialization
	void Start () {
		if (startexist == false) {
			thePlayer = FindObjectOfType<PlayerController> ();
			startexist = true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("SOU UM TRIGGER e QUERO O VALOR theplayer: " + thePlayer.GetInstanceID());
		//Debug.Log ("Chegou esse objeto: " + other.gameObject.GetInstanceID());
		if (other.gameObject.name == "Player") {
			thePlayer.startPoint = exitPoint;
			SceneManager.LoadScene(levelToLoad);

		}
	}
}
