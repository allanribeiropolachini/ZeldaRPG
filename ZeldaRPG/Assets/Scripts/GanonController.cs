using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GanonController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToFire;
	private float timeToFireCounter;
	private Vector3 moveDirection;

	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;

	private bool Spearattacking;
	public float SpearattackTime;
	private float SpearattackTimeCounter;

	private bool Fireattacking;
	public float FireattackTime;
	private float FireattackTimeCounter;

	public float soldados;
	private bool soldadoseliminados;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();

		soldados = 4;

		myRigidbody.isKinematic = true;
		moving = false;
		//SE QUISER VALOR EXATO, DESCOMENTAR LINHAS ABAIXO
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		//moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
		//myRigidbody.velocity = moveDirection;

		//timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		//timeToFireCounter = Random.Range (timeToFire * 0.75f, timeToFire * 1.25f);
		timeBetweenMoveCounter = timeBetweenMove;
		timeToFireCounter = timeToFire;
	}

	// Update is called once per frame
	void Update () {
		/*if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) {
				moving = false;

				//timeBetweenMoveCounter = timeBetweenMove;
				timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}

		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;

			if (timeBetweenMoveCounter < 0f) {
				moving = true;

				//timeToMoveCounter = timeToMove;
				timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

				moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
			}


		}*/
		if (soldadoseliminados) {
			if (timeBetweenMoveCounter >= 0f && !Fireattacking) {
				timeBetweenMoveCounter -= Time.deltaTime;
			} else {
				//Spear ATTACK
				if (timeBetweenMoveCounter < 0f && !moving) {
					moving = true;
					SpearattackTimeCounter = SpearattackTime;
					Spearattacking = true;
					anim.SetBool ("Spear", true);

					myRigidbody.isKinematic = false;
					moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
					myRigidbody.velocity = moveDirection;
				}

				if (SpearattackTimeCounter > 0) {
					SpearattackTimeCounter -= Time.deltaTime;
				}

				if (SpearattackTimeCounter <= 0) {
					//moving = false;
					timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
					//Spearattacking = false;
					anim.SetBool ("Spear", false);

					myRigidbody.isKinematic = true;
					myRigidbody.velocity = Vector2.zero;
				}
			}


			if (timeToFireCounter >= 0f && moving) {
				timeToFireCounter -= Time.deltaTime;
			} else {
				//Spear ATTACK
				if (timeToFireCounter < 0f && Spearattacking == true && !Fireattacking) {
					FireattackTimeCounter = FireattackTime;
					Fireattacking = true;
					anim.SetBool ("Fire", true);

					//myRigidbody.isKinematic = false;
					//moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
					//myRigidbody.velocity = moveDirection;
				}

				if (FireattackTimeCounter > 0) {
					FireattackTimeCounter -= Time.deltaTime;
				}

				if (FireattackTimeCounter <= 0) {
					moving = false;
					timeToFireCounter = Random.Range (timeToFire * 0.75f, timeToFire * 1.25f);
					Fireattacking = false;
					Spearattacking = false;
					anim.SetBool ("Fire", false);

					//myRigidbody.isKinematic = true;
					//myRigidbody.velocity = Vector2.zero;
				}
			}
		} else if (soldados == 0) {
			gameObject.tag = "Enemy";
			soldadoseliminados = true;
			Debug.Log ("Soldados ELIMINADOS");
		}
		/*//Spear ATTACK
		if(Input.GetKeyDown(KeyCode.Y)) {
			SpearattackTimeCounter = SpearattackTime;
			Spearattacking = true;
			anim.SetBool("Spear", true);

			myRigidbody.isKinematic = false;
			moveDirection = new Vector3 (Random.Range (-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
			myRigidbody.velocity = moveDirection;
		}

		if (SpearattackTimeCounter > 0) {
			SpearattackTimeCounter -= Time.deltaTime;
		}

		if (SpearattackTimeCounter <= 0) {
			Spearattacking = false;
			anim.SetBool ("Spear", false);

			myRigidbody.isKinematic = true;
			myRigidbody.velocity = Vector2.zero;
		}*/
	}

}

