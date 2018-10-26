using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;
	private AudioSource audioSource;


	void Start () {
		audioSource = GetComponent<AudioSource> ();
		InvokeRepeating ("Fire", delay, fireRate);
	}


	void Fire () {
		GameObject enemyBullet = ObjectPooler.SharedInstance.GetPooledObject("Enemy Bullet"); 
		if (enemyBullet != null && gameObject.activeSelf) {
			enemyBullet.transform.position = shotSpawn.transform.position;
			enemyBullet.transform.rotation = shotSpawn.transform.rotation;
			enemyBullet.SetActive(true);
			audioSource.Play ();
		}
	}
}