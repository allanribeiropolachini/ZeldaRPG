using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private PlayerStats thePS;
	public Text levelText;


	// Use this for initialization
	void Start () {
		thePS = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		levelText.text = "Level: " + thePS.currentLevel;
	}
}
