using UnityEngine;
using System.Collections;

public class ProjectileTriggerable : MonoBehaviour {

	[HideInInspector] public int gunDamage = 1;
	[HideInInspector] public float projectileLifetime = 2f;
	public GameObject shot;
	public Transform shotSpawn;


	public void Initialize() {  
		
	}


	public void Launch() {
		GameObject missile = ObjectPooler.SharedInstance.GetPooledObject("Player Missile"); 
		if (missile != null) {
			missile.transform.position = new Vector3(shotSpawn.transform.position.x, -0.5f, shotSpawn.transform.position.z);
			missile.transform.rotation = shotSpawn.transform.rotation;
			missile.SetActive (true);
		}
	}
}