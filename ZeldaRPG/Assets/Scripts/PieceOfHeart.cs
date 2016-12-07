using UnityEngine;
using System.Collections;

public class PieceOfHeart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			FindObjectOfType<PlayerController> ().HpCount += 10;
			FindObjectOfType<DialogueManager> ().ShowBox ("HEY! LISTEN! Voce achou um Pedaco de Coracao!!!\n Agora sua Cura Magica recupera +1 coracao.");
			Destroy (gameObject);
		}
	}
}
