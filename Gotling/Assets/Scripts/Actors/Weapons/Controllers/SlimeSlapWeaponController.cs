using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSlapWeaponController : WeaponController
{
    private Transform self;
    private EnemyMovement movement;

    // Start is called before the first frame update
    protected override void Start()
    {
        self = transform.parent.transform;
        movement = self.GetComponent<EnemyMovement>();
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
            movement.MoveTo((Vector2)transform.position + directionVector, weaponData.Speed);
        }
        return result;
    }
}
