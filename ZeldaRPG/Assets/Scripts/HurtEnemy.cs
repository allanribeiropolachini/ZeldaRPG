using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

	public int damageToGive;
	public GameObject damageNumber;
	public Transform hitPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject);
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
		if (other.gameObject.tag == "Box") {
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			//var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
			//clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
		if (other.gameObject.tag == "BoxFairy") {
			other.gameObject.GetComponent<BoxFairy>().HurtEnemy(damageToGive);
			//var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
			//clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
		if (other.gameObject.tag == "Grass") {
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			//var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler (Vector3.zero));
			//clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
	}
}
