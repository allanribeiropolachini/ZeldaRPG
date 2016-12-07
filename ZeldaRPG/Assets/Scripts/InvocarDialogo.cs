using UnityEngine;
using System.Collections;

public class InvocarDialogo : MonoBehaviour {

	public string texto;
	public bool naorepetir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!naorepetir && other.gameObject.name == "Player") {
			FindObjectOfType<DialogueManager> ().ShowBox (texto);
			naorepetir = true;
		}
	}
}
