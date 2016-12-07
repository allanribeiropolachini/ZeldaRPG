using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeLord: MonoBehaviour {

	private Rigidbody2D myRigidbody;
	public float timeBetweenMove;
	public float timeBetweenMoveCounter;

	private bool Shockattacking;
	private float ShockattackTimeCounter;

	private bool avisei;

	public Animator anim;
	//public GameObject Teleport1;

	public float counterteleport;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		counterteleport = 0;
		timeBetweenMoveCounter = timeBetweenMove;
	}

	// Update is called once per frame
	void Update () {
		if (timeBetweenMoveCounter >= 0f) {
			timeBetweenMoveCounter -= Time.deltaTime;
		}
		if (timeBetweenMoveCounter < 0f) {
			counterteleport++;
			if (counterteleport == 5) {
				if (!avisei) {
					FindObjectOfType<DialogueManager> ().ShowBox ("HEY! LISTEN! CUIDADO!!!!! Parece que ele esta furioso.");
					avisei = true;
				}
				anim.speed *= 2f;
				counterteleport = 0;
			}
			gameObject.transform.position = GameObject.Find("Teleport"+counterteleport).transform.position;
			timeBetweenMoveCounter = timeBetweenMove;
		}

	}
}
