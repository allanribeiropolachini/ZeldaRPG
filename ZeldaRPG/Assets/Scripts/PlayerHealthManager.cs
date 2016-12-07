using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	private CameraController maincamera;

	private Animator anim;

	public Quaternion Vector3;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			anim = gameObject.GetComponent<Animator>();


			if(anim.GetBool("CircleAttack"))
				//Debug.Log ("O RETARDADO DO CIRCLEATTACK TA ATIVADO com rotacao: " + transform.rotation.eulerAngles);


			transform.rotation = Quaternion.Euler (0f, 0f, 360f);
			transform.GetChild (0).transform.rotation = Quaternion.Euler (0f, 0f, 360f);

			transform.GetChild (1).transform.position = new Vector3 (0.04000001f, -0.1725f, -0.5f);
			transform.GetChild (1).transform.localScale = new Vector3 (1f, 1f, 1f);

			transform.GetChild (1).transform.GetChild (0).transform.position = new Vector3 (-0.06f, 0.35f, 0f);
			transform.GetChild (1).transform.GetChild (0).transform.localScale = new Vector3 (0.8736647f, 1.549996f, 0.7400429f);


			transform.GetChild (1).transform.rotation = Quaternion.Euler (0f, 0f, 360f);
			transform.GetChild (1).transform.GetChild (0).transform.rotation = Quaternion.Euler (0f, 0f, 360f);

			//Debug.Log ("FICOU COM rotacao: " + transform.rotation.eulerAngles);

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
