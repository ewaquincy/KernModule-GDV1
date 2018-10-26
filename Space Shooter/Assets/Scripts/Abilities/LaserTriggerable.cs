using UnityEngine;
using System.Collections;

public class LaserTriggerable : MonoBehaviour {

	[HideInInspector] public int gunDamage = 1;
	[HideInInspector] public float weaponRange = 20f;
	[HideInInspector] public LineRenderer line;  
//	private float laserMovement;
	private WaitForSeconds shotDuration = new WaitForSeconds(.2f);


	public void Initialize() {  
		line = GetComponent<LineRenderer>();  
		line.enabled = false;
	} 


	public void Fire() {  
			line.enabled = true;  
			line.SetPosition (0, new Vector3(0, -0.1f, 0)); 
//			laserMovement -= 0.02f;
			StartCoroutine(ShotEffect());
			RaycastHit hit;
			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, weaponRange)) {
				line.SetPosition(1, new Vector3(0, -0.1f, hit.distance + 2f));  
				line.material.SetTextureScale ("_MainTex", new Vector2 (hit.distance / 4, 1));
//				line.material.SetTextureOffset ("_MainTex", new Vector2 (laserMovement, 0));
			}
			else {
				line.SetPosition(1, new Vector3(0, -0.1f, weaponRange));
				line.material.SetTextureScale ("_MainTex", new Vector2 (weaponRange / 4, 1));
//				line.material.SetTextureOffset ("_MainTex", new Vector2 (laserMovement, 0));
			}
	}


	private IEnumerator ShotEffect() {
		line.enabled = true;
		yield return shotDuration;
		line.enabled = false;
	}
}