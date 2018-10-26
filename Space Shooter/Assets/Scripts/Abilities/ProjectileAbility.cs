using UnityEngine;
using System.Collections;


[CreateAssetMenu (menuName = "Abilities/ProjectileAbility")]
public class ProjectileAbility : Ability {

	public int gunDamage = 1;
	public float projectileLifetime = 2f;
	public Rigidbody projectile;
	private ProjectileTriggerable launcher;


	public override void Initialize(GameObject obj) {
		launcher = obj.GetComponent<ProjectileTriggerable> ();
	}


	public override void TriggerAbility() {
		launcher.Launch ();
	}
}