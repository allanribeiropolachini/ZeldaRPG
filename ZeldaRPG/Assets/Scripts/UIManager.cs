using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	private PlayerStats thePS;
	public Text levelText;


	// Use this for initialization
	void Start () {
		thePS = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update ( ) {
		if(SceneManager.GetActiveScene().name == "TheEnd")
			transform.GetChild (2).gameObject.SetActive (false);
		else
			transform.GetChild (2).gameObject.SetActive (true);
		levelText.text = "Level: " + thePS.currentLevel;
	}
}
