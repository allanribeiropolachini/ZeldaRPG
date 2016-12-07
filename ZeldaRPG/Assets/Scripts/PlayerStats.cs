using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public int currentLevel;

	public int currentExp;

	//public bool checkEXPstart;

	public int[] toLevelUp;

	private DialogueManager dMan;

	private bool level1;
	private bool level5;
	private bool level10;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentExp >= toLevelUp [currentLevel]) {
			currentLevel++;
		}
		if (currentLevel == 1 && !level1) {
			//GameObject.FindWithTag ("Player").transform.rotation = Quaternion.Euler (0f, 0f, 90f);
			dMan.ShowBox ("HEY! LISTEN! Sua aventura começou!\nUtilize a tecla \"J\" para atacar e \"G\" para bloquear. Sinto uma Magia estranha logo abaixo...");
			level1 = true;
		}
		if (currentLevel == 5 && !level5) {
			dMan.ShowBox ("HEY! LISTEN! Parabens! Voce atingiu o Level 5!\nFoi desbloqueado o Golpe Furacão.\nUtilize a tecla \"K\" para usar esse novo poder.");
			level5 = true;
		}
		if (currentLevel == 10 && !level10) {
			dMan.ShowBox ("HEY! LISTEN! Parabens! Voce atingiu o Level 10!\nFoi desbloqueado o Arco e Flecha.\nUtilize a tecla \"H\" para atacar de longe.");
			level10 = true;
		}
	}

	public void AddExperience(int experienceToAdd){
		currentExp += experienceToAdd;
	}

	public void ZerarTudo(){
		level10 = false;
		level5 = false;
		level1 = false;
	}

	/*void LateUpdate(){
		if (currentExp == 0 && !checkEXPstart) {
			GameObject.FindWithTag ("Player").transform.rotation = Quaternion.Euler (0f, 0f, 360f);
			GameObject.FindWithTag ("Player").transform.GetChild (0).transform.rotation = Quaternion.Euler (0f, 0f, 0f);
			GameObject.FindWithTag ("Player").transform.GetChild (1).transform.rotation = Quaternion.Euler (0f, 0f, 0f);
			checkEXPstart = true;
		}
	}*/
}
