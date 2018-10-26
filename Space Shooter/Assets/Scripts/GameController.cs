using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	public GameObject abilityPanel;
	private bool gameOver;
	private bool restart;
	private int score;
	private bool hasStarted;


	void Start () {
		gameOver = false;
		restart = false;
		hasStarted = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
	}


	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}

		if (abilityPanel.activeSelf == true && hasStarted == false) {
			StartCoroutine (SpawnWaves ());
			hasStarted = true;
		}
	}


	IEnumerator SpawnWaves () {
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				float randomSpawn = Random.Range (0, 3);

				if (randomSpawn == 0) {
					GameObject enemyShip = ObjectPooler.SharedInstance.GetPooledObject ("Enemy"); 
					if (enemyShip != null) {
						enemyShip.transform.position = spawnPosition;
						enemyShip.transform.rotation = spawnRotation;
						enemyShip.SetActive (true);
					}
				} else {
					GameObject enemyAsteroid = ObjectPooler.SharedInstance.GetPooledObject ("Enemy Asteroid"); 
					if (enemyAsteroid != null) {
						enemyAsteroid.transform.position = spawnPosition;
						enemyAsteroid.transform.rotation = spawnRotation;
						enemyAsteroid.SetActive (true);
					}
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}


	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}


	void UpdateScore () {
		scoreText.text = "Score: " + score;
	}


	public void GameOver () {
		gameOverText.text = "Game Over!";
		gameOver = true;
		abilityPanel.SetActive (false);
	}
}