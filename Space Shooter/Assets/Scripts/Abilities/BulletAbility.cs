using UnityEngine;
using System.Collections;


[CreateAssetMenu (menuName = "Abilities/BulletAbility")]
public class BulletAbility : Ability {

	private BulletTriggerable bullet;
	public Material playerMaterial;
	public string bulletTag;


	public override void Initialize(GameObject obj) {
		bullet = obj.GetComponent<BulletTriggerable> ();
		bullet.Initialize ();
		bullet.playerSprite.material  = playerMaterial;
		bullet.playerBullet = bulletTag;
	}


	public override void TriggerAbility() {
		bullet.Shoot ();
	}
}