using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public Text moneyText;
	public int currentGold;

	public static bool gamestarted;
	// Use this for initialization
	void Start () {
		if (!gamestarted) {
			currentGold = 0;
			PlayerPrefs.SetInt ("CurrentMoney", 0);
			gamestarted = true;
		}

		if (PlayerPrefs.HasKey ("CurrentMoney")) {
			currentGold = PlayerPrefs.GetInt ("CurrentMoney");
		} else {
			currentGold = 0;
			PlayerPrefs.SetInt ("CurrentMoney", 0);
		}

		moneyText.text = "Rupee: " + currentGold;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddMoney(int goldToAdd){
		currentGold += goldToAdd;
		PlayerPrefs.SetInt ("CurrentMoney", currentGold);
		moneyText.text = "Rupee: " + currentGold;
	}
}
