using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;

	private PlayerStats thePlayerStats;

	public int expToGive;

	public GameObject Rupee;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;

		thePlayerStats = FindObjectOfType<PlayerStats> ();
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			Instantiate (Rupee, transform.position, transform.rotation);
			Destroy (gameObject);
			thePlayerStats.AddExperience (expToGive);
		}
	}

	public void HurtEnemy(int damageToGive){
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		CurrentHealth = MaxHealth;
	}
}
