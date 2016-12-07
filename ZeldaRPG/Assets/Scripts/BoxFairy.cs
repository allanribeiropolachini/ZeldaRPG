using UnityEngine;
using System.Collections;

public class BoxFairy : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;

	public GameObject Fairy;

	public Renderer rend;
	private DialogueManager dMan;

	private Vector3 Boxposition;
	private bool boxopenned;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		dMan = FindObjectOfType<DialogueManager> ();
		rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0 && !boxopenned && FindObjectOfType<PlayerController>().Fairyunlock == false) {
				rend.enabled = true;
				Boxposition = transform.position; 
				//Boxposition += new Vector3 (0f, -2f, 0f);
				//Instantiate (Fairy, Boxposition, transform.rotation);
				FindObjectOfType<PlayerController>().Fairyunlock = true;
				GameObject.FindWithTag("Canvas").transform.GetChild (3).gameObject.SetActive (true);
				Fairy.SetActive(true);
				dMan.ShowBox ("HEY! LISTEN! Essa magia estranha era a habilidade Cura Magica. Agora voce pode usa-la ao clicar a tecla \"B\". Mas use com cuidado pois ela tem tempo de recarga de 30s.");
				boxopenned = true;
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			Fairy.SetActive(false);
		}
	}

	public void HurtEnemy(int damageToGive){
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		CurrentHealth = MaxHealth;
	}
}
