using UnityEngine;
using System.Collections;

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

	private bool Bowattacking;
	public float BowattackTime;
	private float BowattackTimeCounter;

	public string startPoint;

	private PlayerStats levelscript;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D> ();


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
		levelscript = FindObjectOfType<PlayerStats> ();
		playerMoving = false;

		if(true){
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				//transform.Translate(new Vector3 ( Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				myRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * moveSpeed, myRigidbody.velocity.y);
				playerMoving = true;	
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//transform.Translate(new Vector3 (0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * moveSpeed);
				playerMoving = true;	
				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);

			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);

			}
		}

		//NORMAL ATTACK
		if(Input.GetKeyDown(KeyCode.J)) {
			attackTimeCounter = attackTime;
			attacking = true;
			myRigidbody.velocity = Vector2.zero;
			anim.SetBool("Attack", true);
		}

		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
		}

		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);
		}

		//CIRCLE ATTACK
		if(Input.GetKeyDown(KeyCode.K) && levelscript.currentLevel >= 5) {
			CircleattackTimeCounter = CircleattackTime;
			Circleattacking = true;
			myRigidbody.velocity = Vector2.zero;
			anim.SetBool("CircleAttack", true);
		}

		if (CircleattackTimeCounter > 0) {
			CircleattackTimeCounter -= Time.deltaTime;
		}

		if (CircleattackTimeCounter <= 0) {
			Circleattacking = false;
			anim.SetBool ("CircleAttack", false);
		}

		//BOW ATTACK
		if(Input.GetKeyDown(KeyCode.H) && levelscript.currentLevel >= 10) {
			BowattackTimeCounter = BowattackTime;
			Bowattacking = true;
			myRigidbody.velocity = Vector2.zero;
			anim.SetBool("AttackBow", true);
		}

		if (BowattackTimeCounter > 0) {
			BowattackTimeCounter -= Time.deltaTime;
		}

		if (BowattackTimeCounter <= 0) {
			Bowattacking = false;
			anim.SetBool ("AttackBow", false);
		}

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("PlayerMoving", playerMoving);
		anim.SetFloat("LastMoveX", lastMove.x);
		anim.SetFloat("LastMoveY", lastMove.y);
	}
}
