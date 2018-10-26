using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour {

	public string abilityButtonAxisName = "";
	public Image darkMask;
	private Ability ability;
	private GameObject weaponHolder;
	private Image myButtonImage;
	private AudioSource abilitySource;
	private float cooldownDuration;
	private float nextReadyTime;
	private float cooldownTimeLeft;


	public void Initialize (Ability selectedAbility, GameObject weaponHolder) {
		ability = selectedAbility;
		myButtonImage = GetComponent<Image> ();
		abilitySource = GetComponent<AudioSource> ();
		myButtonImage.sprite = ability.aSprite;
		darkMask.sprite = ability.aSprite;
		cooldownDuration = ability.aBaseCooldown;
		ability.Initialize (weaponHolder);
		AbilityReady ();
	}


	void Update () {
		bool cooldownComplete = (Time.time > nextReadyTime);
		if (cooldownComplete) {
			AbilityReady ();
			if (Input.GetButtonDown (abilityButtonAxisName)) {
				ButtonTriggered ();
			} 
		} else {
				Cooldown ();
			}
	}


	private void AbilityReady() {
		darkMask.enabled = false;
	}


	private void Cooldown() {
		cooldownTimeLeft -= Time.deltaTime;
		darkMask.fillAmount = (cooldownTimeLeft / cooldownDuration);
	}


	private void ButtonTriggered() {
		nextReadyTime = cooldownDuration + Time.time;
		cooldownTimeLeft = cooldownDuration;
		darkMask.enabled = true;
		abilitySource.clip = ability.aSound;
		abilitySource.Play ();
		ability.TriggerAbility ();
	}
}