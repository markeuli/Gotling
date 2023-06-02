using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeProjectileBase : ProjectileBase
{
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        var obj = col.GetComponent<DamageableObject>();
        if (obj != null)
        {
            obj.TakeDamage(currentDamage, gameObject.transform.parent.gameObject);
        }
    }

    public override void SetupProjectile(Vector3 dir, Team team = Team.Player)
    {
        base.SetupProjectile(dir, team);
        body.velocity = direction * weaponData.Speed;
    }
}
