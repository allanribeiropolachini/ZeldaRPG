using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;

	public Image HeartUI;

	private PlayerHealthManager thePlayer;



	void Start(){
		thePlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealthManager> ();
		
	}

	void Update(){
		HeartUI.sprite = HeartSprites [thePlayer.playerCurrentHealth / 10];
	}
}
