using UnityEngine;
using System.Collections;


[CreateAssetMenu (menuName = "Abilities/LaserAbility")]
public class LaserAbility : Ability {

	public int gunDamage = 1;
	public float weaponRange = 20;
	public Color laserColor = Color.white;
	private LaserTriggerable laserShoot;


	public override void Initialize(GameObject obj) {
		laserShoot = obj.GetComponent<LaserTriggerable> ();
		laserShoot.Initialize ();
		laserShoot.gunDamage = gunDamage;
		laserShoot.weaponRange = weaponRange;
	}


	public override void TriggerAbility()
	{
		laserShoot.Fire ();
	}
}