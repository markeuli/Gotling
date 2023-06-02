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

    public override bool Attack(Vector2 direction)
    {
        bool result = base.Attack(direction);
        if (result)
        {
            var mouseVector = (direction - (Vector2)transform.position).normalized;
            GameObject spawnedKnife = Instantiate(weaponData.Prefab);
            spawnedKnife.transform.position = transform.position;
            spawnedKnife.GetComponent<RangedProjectileBase>().SetupProjectile(mouseVector, team);
        }
        return result;
    }
}
