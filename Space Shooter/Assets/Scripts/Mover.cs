using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public float speed;


	void OnEnable () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * speed;
	}
}