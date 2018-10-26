using UnityEngine;
using System.Collections;

public class RandomMesh : MonoBehaviour {

	public GameObject[] asteroidPrefabs;


	void Start () {
		GameObject myAsteroid = Instantiate (asteroidPrefabs[Random.Range (0, asteroidPrefabs.Length)], this.transform, false) as GameObject;
	}
}