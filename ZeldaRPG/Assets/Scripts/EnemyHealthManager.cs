using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;

	private PlayerStats thePlayerStats;

	public int expToGive;

	public GameObject Rupee;

	public Renderer rend;

	private Vector3 Boxposition;
	private bool boxopenned;

	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;

		if (gameObject.name == "boxsprite_open") {
			rend = GetComponent<Renderer>();
		}

		thePlayerStats = FindObjectOfType<PlayerStats> ();
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			if (gameObject.tag == "Grass") {
				if(Random.Range(0f,100f) >= 50f)
					Instantiate (Rupee, transform.position, transform.rotation);
				Destroy (gameObject);
			}else if (gameObject.name == "boxsprite_open" && boxopenned == false) {
				rend.enabled = true;
				Boxposition = transform.position; 
				Boxposition += new Vector3 (0f, -2f, 0f);
				Instantiate (Rupee, Boxposition, transform.rotation);
				boxopenned = true;
			} else if (gameObject.name != "boxsprite_open") {
				Instantiate (Rupee, transform.position, transform.rotation);
				Destroy (gameObject);
				thePlayerStats.AddExperience (expToGive);
			}
		}
	}

	public void HurtEnemy(int damageToGive){
		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		CurrentHealth = MaxHealth;
	}
}
