using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;

	private Animator anim;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	public Vector2 lastMove;

	public static bool playerExists;

	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	private bool Circleattacking;
	public float CircleattackTime;
	private float CircleattackTimeCounter;

	private bool Blessattacking;
	public float BlessattackTime;
	private float BlessattackTimeCounter;

	public int HpCount;

	private bool BlessCD;
	public float BlessCDTime;
	private float BlessCDTimeCounter;

	private bool Bowattacking;
	public float BowattackTime;
	private float BowattackTimeCounter;

	private bool Shieldattacking;
	public float ShieldattackTime;
	private float ShieldattackTimeCounter;

	private static bool playerStarted;
	public bool Fairyunlock;

	public string startPoint;

	private PlayerStats levelscript;

	private PlayerHealthManager Life_player;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();

		HpCount = 10;

		if (SceneManager.GetActiveScene ().name == "main") {
			playerStarted = false;
		}

		//Debug.Log ("Valor playerExists:" + playerExists);
		//Debug.Log ("Esse objeto sera destruido? : " + GetInstanceID());
		if (!playerExists) {
			//Debug.Log ("Nao destrui");
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			//Debug.Log ("Morreu");
			Destroy (this);
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0) {
			levelscript = FindObjectOfType<PlayerStats> ();
			playerMoving = false;



			if (!Blessattacking && !Shieldattacking) {
				if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
					//transform.Translate(new Vector3 ( Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
					myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, myRigidbody.velocity.y);
					playerMoving = true;	
					lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
					playerStarted = true;
				}

				if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
					//transform.Translate(new Vector3 (0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
					myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
					playerMoving = true;	
					lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
					playerStarted = true;
				}

				if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
					myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);
				}

				if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
					myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
				}
			}

			//NORMAL ATTACK
			if (Input.GetKeyDown (KeyCode.J) && playerStarted) {
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);
			}

			if (attackTimeCounter > 0) {
				attackTimeCounter -= Time.deltaTime;
			}

			if (attackTimeCounter <= 0) {
				attacking = false;
				anim.SetBool ("Attack", false);
			}

			//CIRCLE ATTACK
			if (Input.GetKeyDown (KeyCode.K) && levelscript.currentLevel >= 5 && playerStarted) {
				CircleattackTimeCounter = CircleattackTime;
				Circleattacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("CircleAttack", true);
			}

			if (CircleattackTimeCounter > 0) {
				CircleattackTimeCounter -= Time.deltaTime;
			}

			if (CircleattackTimeCounter <= 0) {
				Circleattacking = false;
				anim.SetBool ("CircleAttack", false);
			}

			//Bless
			if (Input.GetKeyDown (KeyCode.B) && !Shieldattacking && playerStarted && Fairyunlock && !BlessCD) {
				FindObjectOfType<PlayerHealthManager> ().playerCurrentHealth += HpCount;
				//Life_player = GetComponent<PlayerHealthManager> ();
				//Life_player.SetMaxHealth();

				BlessattackTimeCounter = BlessattackTime;
				Blessattacking = true;

				BlessCDTimeCounter = BlessCDTime;
				BlessCD = true;
				GameObject.FindWithTag ("Canvas").transform.GetChild (3).gameObject.SetActive (false);

				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Bless", true);
			}

			if (BlessattackTimeCounter > 0) {
				BlessattackTimeCounter -= Time.deltaTime;
			}

			if (BlessattackTimeCounter <= 0) {
				Blessattacking = false;
				anim.SetBool ("Bless", false);
			}

			if (BlessCDTimeCounter > 0) {
				BlessCDTimeCounter -= Time.deltaTime;
			}

			if (BlessCDTimeCounter <= 0 && Fairyunlock) {
				GameObject.FindWithTag ("Canvas").transform.GetChild (3).gameObject.SetActive (true);
				BlessCD = false;
			}

			//BOW ATTACK
			if (Input.GetKeyDown (KeyCode.H) && levelscript.currentLevel >= 10 && playerStarted) {
				BowattackTimeCounter = BowattackTime;
				Bowattacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("AttackBow", true);
			}

			if (BowattackTimeCounter > 0) {
				BowattackTimeCounter -= Time.deltaTime;
			}

			if (BowattackTimeCounter <= 0) {
				Bowattacking = false;
				anim.SetBool ("AttackBow", false);
			}

			//SHIELD
			/*if(Input.GetKeyDown(KeyCode.G)) {
				transform.gameObject.name = "Untagged";
				ShieldattackTimeCounter = ShieldattackTime;
				Shieldattacking = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool("Shield", true);
			}

			if (ShieldattackTimeCounter > 0) {
				ShieldattackTimeCounter -= Time.deltaTime;
			}

			if (ShieldattackTimeCounter <= 0) {
				transform.gameObject.name = "Player";
				Shieldattacking = false;
				anim.SetBool ("Shield", false);
			}*/

			if (Input.GetKeyDown (KeyCode.G) && playerStarted) {
				transform.gameObject.name = "Untagged";
				//ShieldattackTimeCounter = ShieldattackTime;
				Shieldattacking = true;
				myRigidbody.isKinematic = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Shield", true);
			}

			//if (ShieldattackTimeCounter > 0) {
			//	ShieldattackTimeCounter -= Time.deltaTime;
			//}

			if (Input.GetKeyUp (KeyCode.G) && playerStarted) {
				transform.gameObject.name = "Player";
				myRigidbody.isKinematic = false;
				Shieldattacking = false;
				anim.SetBool ("Shield", false);
			}

			anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
			anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
			anim.SetBool ("PlayerMoving", playerMoving);
			anim.SetFloat ("LastMoveX", lastMove.x);
			anim.SetFloat ("LastMoveY", lastMove.y);
		}
	}
}
