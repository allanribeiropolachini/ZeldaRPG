using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

	private static PlayerController thePlayer;
	private CameraController theCamera;

	public Vector2 startDirection;

	public string pointname;

	public static bool startexist;

	public static bool chegueiTemplo1;

	// Use this for initialization
	void Start () {
		//Debug.Log ("VALOR DO STARTEXIST: " + startexist);
		if (startexist == false) {
			thePlayer = FindObjectOfType<PlayerController> ();
			startexist = true;
		}

		//thePlayer = FindObjectOfType<LoadNewArea> ().thePlayer;

		//Debug.Log ("Vou entrar NO STARTPOINT com o objeto: " + thePlayer.GetInstanceID ());
		//Debug.Log(" valores startpoint: " + thePlayer.startPoint + ", e pointname: " + pointname);
		if (thePlayer.startPoint == pointname) {
			if (gameObject.name == "StartPointTemplo1" && !chegueiTemplo1) {
				FindObjectOfType<DialogueManager> ().ShowBox ("HEY! LISTEN! Esse é o Templo do Tempo... Tenha cuidado, pois tem muitas armadilhas lá.");
			}
			//Debug.Log ("Entrei Aqui");
			thePlayer.transform.position = transform.position;
			thePlayer.lastMove = startDirection;

			theCamera = FindObjectOfType<CameraController> ();
			theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
