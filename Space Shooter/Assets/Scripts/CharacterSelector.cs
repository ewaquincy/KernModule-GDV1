using UnityEngine;
using System.Collections;

public class CharacterSelector : MonoBehaviour {

	public GameObject player;
	public Vector3 playerSpawnPosition = new Vector3 (0, 0, 0);
	public Character[] characters;

	public GameObject characterSelectPanel;
	public GameObject abilityPanel;


	public void OnCharacterSelect(int characterChoice) {
		characterSelectPanel.SetActive (false);
		abilityPanel.SetActive (true);
		GameObject spawnedPlayer = Instantiate (player, playerSpawnPosition, Quaternion.identity) as GameObject;
		WeaponMarker weaponMarker = spawnedPlayer.GetComponentInChildren<WeaponMarker> ();
		AbilityCooldown[] cooldownButtons = GetComponentsInChildren <AbilityCooldown> ();
		Character selectedCharacter = characters [characterChoice];
		for (int i = 0; i < cooldownButtons.Length; i++) {
			cooldownButtons[i].Initialize(selectedCharacter.characterAbilities[i], weaponMarker.gameObject);
		}
	}
}