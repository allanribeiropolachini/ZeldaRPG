using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SlimeController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;

	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		//SE QUISER VALOR EXATO, DESCOMENTAR LINHAS ABAIXO
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
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


		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
				//Se quiser só voltar para o startPoint, comentar linha de cima e descomentar abaixo
				//thePlayer.transform.position = new Vector2(FindObjectOfType<PlayerStartPoint>().transform.position.x, FindObjectOfType<PlayerStartPoint>().transform.position.y);
				thePlayer.SetActive (true);
				//reloading = false;
			}
		}

	}

	/*void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "Player") {
			//Destroy (other.gameObject);
			other.gameObject.SetActive(false);
			reloading = true;
			thePlayer = other.gameObject;
		}
	}*/
}
