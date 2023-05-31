using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeProjectileBase : ProjectileBase
{
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("finding ouch");
        var obj = col.GetComponent<DamageableObject>();
        if (obj != null)
        {
            Debug.Log("doing ouch");
            obj.TakeDamage(currentDamage);
        }
    }

    public override void SetupProjectile(Vector3 dir, Team team = Team.Player)
    {
        base.SetupProjectile(dir, team);
        body.velocity = direction * weaponData.Speed;
    }
}
