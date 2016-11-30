using UnityEngine;
using System.Collections;

public class EnemySlimeController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	private bool movingUP;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();


		timeBetweenMoveCounter = timeBetweenMove;
		timeToMoveCounter = timeToMove;

		//timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		//timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

	}

	// Update is called once per frame
	void Update () {
		if (movingUP) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeToMoveCounter < 0f) {
				movingUP = false;

				timeBetweenMoveCounter = timeBetweenMove;
				//timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

				moveDirection = new Vector3 (0f, -1f * moveSpeed, 0f);
			}

		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;

			if (timeBetweenMoveCounter < 0f) {
				movingUP = true;

				timeToMoveCounter = timeToMove;
				//timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);

				moveDirection = new Vector3 (0f, 1f * moveSpeed, 0f);
			}


		}

	}
}
