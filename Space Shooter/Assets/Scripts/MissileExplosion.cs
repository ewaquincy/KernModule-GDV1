using UnityEngine;
using System.Collections;

public class MissileExplosion : MonoBehaviour {

	public float delay = 3f;

	public GameObject explosionEffect;

	float countdown;
	bool hasExploded;


	void OnEnable () {
		hasExploded = false;
		countdown = delay;
	}
	

	void Update () {
		countdown -= Time.deltaTime;
		if (countdown <= 0f && !hasExploded) {
			Explode ();
			hasExploded = true;
		}
	}


	void Explode () {
		Instantiate (explosionEffect, transform.position, transform.rotation);
		gameObject.SetActive(false);
	}
}