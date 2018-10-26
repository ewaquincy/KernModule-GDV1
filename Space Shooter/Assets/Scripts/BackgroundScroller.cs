using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed;
	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPos = Mathf.Repeat (Time.time * scrollSpeed, transform.localScale.y);
		transform.position = startPos + Vector3.forward * newPos;
	}
}
