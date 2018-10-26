using UnityEngine;
using System.Collections;

public class BulletTriggerable : MonoBehaviour {

	public string playerBullet = "";
	public Transform shotSpawn;
	[HideInInspector] public MeshRenderer playerSprite;


	public void Initialize() {  
		playerSprite = GetComponent<MeshRenderer>(); 
	}
	

	public void Shoot () {
		GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(playerBullet); 
		if (bullet != null) {
			bullet.transform.position = shotSpawn.transform.position;
			bullet.transform.rotation = shotSpawn.transform.rotation;
			bullet.SetActive(true);
		}
	}
}