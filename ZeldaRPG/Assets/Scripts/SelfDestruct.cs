﻿using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	public float timer = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			Destroy (gameObject);
		}
			
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag != "Player" && other.gameObject.tag != "Rupee" && other.gameObject.tag != "BoundsCamera") {
			Destroy (gameObject);
		}
	}
}
