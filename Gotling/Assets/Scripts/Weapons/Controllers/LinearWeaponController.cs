using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearWeaponController : WeaponController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override bool Attack(Vector2 playerMouse)
    {
        bool result = base.Attack(playerMouse);
        if (result)
        {
            var mouseVector = (playerMouse - (Vector2)transform.position).normalized;
            GameObject spawnedKnife = Instantiate(weaponData.Prefab);
            spawnedKnife.transform.position = transform.position;
            spawnedKnife.GetComponent<RangedProjectileBase>().SetupProjectile(mouseVector);
        }
        return result;
    }
}
