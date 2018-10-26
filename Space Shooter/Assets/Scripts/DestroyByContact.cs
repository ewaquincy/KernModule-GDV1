using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	public GameObject missileExplosion;


	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Boundary") || 
			other.CompareTag ("Enemy") ||
			other.CompareTag ("Enemy Bullet") ||
			other.CompareTag ("Enemy Asteroid")) {
			return;
		}

		if (explosion != null) {
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.CompareTag ("Player")) {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore (scoreValue);
		gameObject.SetActive(false);

		if (other.CompareTag ("Player Missile")) {
			Instantiate(missileExplosion, other.transform.position, other.transform.rotation);
		}

		if (!other.CompareTag ("Missile Explosion")) {
		other.gameObject.SetActive(false);
		}
	}
}