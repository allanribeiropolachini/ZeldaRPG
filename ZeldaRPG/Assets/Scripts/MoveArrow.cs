using UnityEngine;
using System.Collections;

public class MoveArrow : MonoBehaviour {

	public float maxSpeed = 5f;

	private PlayerController thePlayer;

	private bool shotted;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}

	// Update is called once per frame
	void Update () {
		

		Vector3 pos = transform.position;

		Vector3 velocity = new Vector3 (0f, maxSpeed * Time.deltaTime, 0f);

		if (thePlayer.lastMove.x == -1 && !shotted) {
			transform.rotation = Quaternion.Euler (0f, 0f, 90f);
			shotted = true;
		} else if(thePlayer.lastMove.x == 1 && !shotted) {
			transform.rotation = Quaternion.Euler (0f, 0f, -90f);
			shotted = true;
		} else if(thePlayer.lastMove.y == -1 && !shotted) {
			transform.rotation = Quaternion.Euler (0f, 0f, 180f);
			shotted = true;
		} else if(thePlayer.lastMove.y == 1 && !shotted) {
			transform.rotation = Quaternion.Euler (0f, 0f, 0f);
			shotted = true;
		}

		pos += transform.rotation * velocity;

		transform.position = pos;
	}
}
