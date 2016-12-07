using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

		if (gameObject.name == "boxsprite_open" || gameObject.name == "boxsprite_open_unlock") {
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
			} else if (gameObject.name == "boxsprite_open_unlock" && boxopenned == false) {
				rend.enabled = true;
				//Instantiate (Rupee, transform.position, transform.rotation);
				FindObjectOfType<DialogueManager>().ShowBox ("HEY! LISTEN! Parece que a proxima sala foi desbloqueada...\nMas acho esse caminho nao tera volta...");
				FindObjectOfType<LoadNewArea> ().templo2 = true;
				//thePlayerStats.AddExperience (expToGive);
				boxopenned = true;
			} else if (gameObject.name == "timeLORD") {
				FindObjectOfType<DialogueManager>().ShowBox ("HEY! LISTEN! ...uma dica pra voce, \"Rosas sao ...\"");
				FindObjectOfType<LoadNewArea> ().templo3 = true;

				Boxposition = transform.position; 
				Boxposition += new Vector3 (0f, -2f, 0f);
				Instantiate (Rupee, Boxposition, transform.rotation);
				thePlayerStats.AddExperience (expToGive);
				Destroy (gameObject);
			}else if (gameObject.name == "spritesoldado_0") {
				FindObjectOfType<GanonController> ().soldados -= 1f;
				Instantiate (Rupee, transform.position, transform.rotation);
				Destroy (gameObject);
				thePlayerStats.AddExperience (expToGive);
			}else if (gameObject.name == "Ganon") {
				Destroy (gameObject);
				SceneManager.LoadScene ("HappyEnd");
			}else if (gameObject.name != "boxsprite_open") {
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
