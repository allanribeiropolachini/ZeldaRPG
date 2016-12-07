using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

	public string levelToLoad;

	public string exitPoint;

	public static PlayerController thePlayer;

	public static bool startexist;

	public bool templo1;
	public bool templo2;
	public bool templo3;

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
		//Debug.Log ("SOU UM TRIGGER e QUERO O VALOR theplayer: " + thePlayer.GetInstanceID());
		//Debug.Log ("Chegou esse objeto: " + other.gameObject.GetInstanceID());
		if (other.gameObject.name == "Player") {
			if (gameObject.name == "exitTemplo2") {
				if (templo2) {
					thePlayer.startPoint = exitPoint;
					SceneManager.LoadScene (levelToLoad);
				} else {
					FindObjectOfType<DialogueManager> ().ShowBox ("HEY! LISTEN! Tem outra barreira invisivel... Mas acho que sua fonte esta aqui perto...");
				}
			}else if (gameObject.name == "exitTemplo1") {
				if (templo1) {
					thePlayer.startPoint = exitPoint;
					SceneManager.LoadScene (levelToLoad);
				} else {
					FindObjectOfType<DialogueManager> ().ShowBox ("HEY! LISTEN! Tem uma barreira invisivel impedindo nossa entrada...\nAcho que com mais Rupees eu consigo quebra-la.");
					FindObjectOfType<MoneyManager> ().NotificacaoFadinha = true;
				}
		}else if (gameObject.name == "exitTemplo3") {
			if (templo3) {
				thePlayer.startPoint = exitPoint;
				SceneManager.LoadScene (levelToLoad);
			} else {
					
			}
		} else {
				thePlayer.startPoint = exitPoint;
				SceneManager.LoadScene (levelToLoad);
			}
		}
	}
}
