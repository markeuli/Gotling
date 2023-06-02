using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeleeWeaponController : WeaponController
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
            var directionVector = (direction - (Vector2)transform.position).normalized;
            GameObject proj = Instantiate<GameObject>(weaponData.Prefab, transform.position, transform.rotation, transform.parent);
            proj.GetComponent<SimpleMeleeProjectile>().SetupProjectile(directionVector, team);
        }
        return result;
    }
}
