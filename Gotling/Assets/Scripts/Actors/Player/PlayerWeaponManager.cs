using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public WeaponController primary { get; private set; }
    public WeaponController secondary { get; private set; }

    public void SetPrimary(GameObject weapon)
    {
        if (primary != null)
        {
            Destroy(primary.gameObject);
        }

        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        primary = spawnedWeapon.GetComponent<WeaponController>();
    }
    public void SetSecondary(GameObject weapon)
    {
        if (secondary != null)
        {
            Destroy(secondary.gameObject);
        }

        GameObject spawnedWeapon = Instantiate(weapon, transform.position, Quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        secondary = spawnedWeapon.GetComponent<WeaponController>();
    }
}
