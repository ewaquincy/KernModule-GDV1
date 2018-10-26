using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class MoverHoming : MonoBehaviour {

	public Transform target;
	private Rigidbody rb;
	public float speed;
	// public float rotateSpeed;

	void OnEnable () {
		rb = GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag ("Enemy Asteroid").transform;
		rb.velocity = transform.forward * speed;
	}


	void FixedUpdate () {
		if (target != null) {
		rb.velocity = ((target.position - transform.position) * speed);
		transform.LookAt (target.position);
		}
			
		/*
		// Slow missile, orbiting
		rb.AddForce((target.position - transform.position)*speed);
		transform.rotation = Quaternion.LookRotation (rb.velocity);
		*/


		/* 
		// Not working missile fml
		Vector3 direction = target.position - rb.position;
		direction.Normalize ();
		float rotateAmount = Vector3.Cross(direction, transform.right).y;
		Debug.Log ("This is the direction" + direction);
		Debug.Log ("Velocitye" + rb.angularVelocity);
		rb.angularVelocity = transform.position * (-rotateAmount * rotateSpeed);
		// rb.velocity = transform.forward * speed;
		*/
	}
}