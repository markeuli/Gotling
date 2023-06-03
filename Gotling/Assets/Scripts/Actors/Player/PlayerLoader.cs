using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerWeaponManager))]
[RequireComponent(typeof(DamageableObject))]
[RequireComponent(typeof(LevelManager))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var characterData = CharacterSelector.GetData();
        CharacterSelector.instance.DestroySingleton();

        var weapons = GetComponent<PlayerWeaponManager>();
        weapons.SetPrimary(characterData.StartingWeapon);

        var damage = GetComponent<DamageableObject>();
        damage.SetMaximum(characterData.MaxHealth, true);

        var healthbar = GetComponentInChildren<HealthBarController>();
        damage.OnHealthChange += healthbar.SetHealthbar;

        var level = GetComponent<LevelManager>();
        level.SetStartingLevel(1, 100); // TODO remove magic number max level

        Destroy(this);
    }
}
