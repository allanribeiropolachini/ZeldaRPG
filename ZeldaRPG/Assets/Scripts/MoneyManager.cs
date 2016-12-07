using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

	public Text moneyText;
	public int currentGold;

	public bool NotificacaoFadinha;
	public bool naorepetir;

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
		if (currentGold >= 20 && NotificacaoFadinha && !naorepetir) {
			FindObjectOfType<DialogueManager> ().ShowBox ("Hey!Listen! Com essas 20 rupees eu consigo quebrar a barreira para entrar no Templo do Tempo");
			FindObjectOfType<LoadNewArea> ().templo1 = true;
			naorepetir = true;
		}
	}

	public void AddMoney(int goldToAdd){
		currentGold += goldToAdd;
		PlayerPrefs.SetInt ("CurrentMoney", currentGold);
		moneyText.text = "Rupee: " + currentGold;
	}
}
