using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	public GameObject newPlayer;
	private Vector3 targetPos;
	public float moveSpeed;

	private Animator anim;

	private PlayerHealthManager phm;
	private PlayerStats ps;

	private static bool cameraExists;

	public bool followIsDead;

	private MoneyManager moneyManager;

	//public BoxCollider2D boundBox;
	//private Vector3 minBounds;
	//private Vector3 maxBounds;

	//private Camera theCamera;
	//private float halfHeight;
	//private float halfWidth;

	public bool Revived;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);

		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

		//minBounds = boundBox.bounds.min;
		//maxBounds = boundBox.bounds.max;

		//theCamera = GetComponent<Camera> ();
		//halfHeight = theCamera.orthographicSize;
		//halfWidth = halfHeight * Screen.width / Screen.height;

	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name == "main" && followIsDead == true) {
			followTarget.SetActive (true);
			phm = FindObjectOfType<PlayerHealthManager> ();
			ps = FindObjectOfType<PlayerStats> ();
			FindObjectOfType<PlayerController> ().startPoint = "House Out";
			FindObjectOfType<PlayerController> ().HpCount = 10;
			FindObjectOfType<PlayerController> ().Fairyunlock = false;
			FindObjectOfType<PlayerController> ().BlessCDTimeCounter = 0;
			GameObject.FindWithTag("Canvas").transform.GetChild (3).gameObject.SetActive (false);


			moneyManager = FindObjectOfType<MoneyManager> ();
			//anim = FindObjectOfType<Animator>();
			//anim.enabled = true;

			Revived = true;

			moneyManager.currentGold = 0;
			PlayerPrefs.SetInt ("CurrentMoney", 0);
			moneyManager.moneyText.text = "Rupee: 0";
			ps.currentExp = 0;
			ps.currentLevel = 0;
			ps.ZerarTudo ();

			phm.SetMaxHealth();
			followIsDead = false;
		}
		targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	
		//float clampedX = Mathf.Clamp (transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
		//float clampedY = Mathf.Clamp (transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
		//transform.position = new Vector3 (clampedX, clampedY, transform.position.z);
	}

	public void SetBounds(BoxCollider2D newBounds){
		//boundBox = newBounds;
		//minBounds = boundBox.bounds.min;
		//maxBounds = boundBox.bounds.max;
	}

	void LateUpdate(){
		//Debug.Log ("Valor do REVIVED: " + Revived + "Valor do antigo rotation: " + followTarget.transform.rotation);
		if (Revived) {
			followTarget.transform.rotation = Quaternion.Euler (0f, 0f, -90f);
			followTarget.transform.GetChild (0).transform.rotation = Quaternion.Euler (0f, 0f, 0f);
			followTarget.transform.GetChild (1).transform.rotation = Quaternion.Euler (0f, 0f, 0f);
			Revived = false;
			//Debug.Log ("NOVO ROTATION: " + followTarget.transform.rotation);
		}

	}

}
