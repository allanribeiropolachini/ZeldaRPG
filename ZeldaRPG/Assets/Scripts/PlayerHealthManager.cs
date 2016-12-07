using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	private CameraController maincamera;

	private Animator anim;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			anim = gameObject.GetComponent<Animator>();
			anim.SetBool ("Attack", false);
			anim.SetBool ("AttackBow", false);
			anim.SetBool ("CircleAttack", false);
			anim.SetBool ("Bless", false);
			anim.SetBool ("Shield", false);
			transform.GetChild (3).gameObject.SetActive (false);
			transform.GetChild (4).gameObject.SetActive (false);
			gameObject.SetActive (false);
			maincamera = FindObjectOfType<CameraController> ();
			maincamera.followIsDead = true;
			SceneManager.LoadScene("TheEnd");
		}
	}

	public void HurtPlayer(int damageToGive){
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		playerCurrentHealth = playerMaxHealth;
	}

	public void SetActivePlayer(){
		gameObject.SetActive (true);
	}
}
