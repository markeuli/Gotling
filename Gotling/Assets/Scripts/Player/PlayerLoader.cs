using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var characterData = CharacterSelector.GetData();
        CharacterSelector.instance.DestroySingleton();

        var weapons = GetComponent<PlayerWeaponManager>();

        weapons.SetPrimary(characterData.StartingWeapon);

        Destroy(this);
    }
}
