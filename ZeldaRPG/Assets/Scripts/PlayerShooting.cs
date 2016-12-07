using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public Vector3 arrowOffset;

	//Vector3 arrowOffsetrotation = new Vector3 (0f, 0f, 90f);

	public GameObject arrowPrefab;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

	private PlayerStats levelscript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer -= Time.deltaTime;
		levelscript = FindObjectOfType<PlayerStats> ();

		if (Input.GetKeyDown (KeyCode.H) && cooldownTimer <= 0 && levelscript.currentLevel >= 10) {
			//SHOOT!
			//Debug.Log("Atirei!");
			cooldownTimer = fireDelay;

			Vector3 offset = transform.rotation * arrowOffset;

			Instantiate (arrowPrefab, transform.position + offset, transform.rotation);
		}
	}
}
