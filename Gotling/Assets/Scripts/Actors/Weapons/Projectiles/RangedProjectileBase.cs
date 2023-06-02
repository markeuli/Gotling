using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedProjectileBase : ProjectileBase
{
    protected int currentPierce;

    protected override void Awake()
	{
        currentPierce = weaponData.Pierce;
        base.Awake();
    }

    public override void SetupProjectile(Vector3 dir, Team team = Team.Player)
    {
        base.SetupProjectile(dir, team);
        body.velocity = direction * weaponData.Speed;
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        var obj = col.GetComponent<DamageableObject>();
        if (obj != null)
        {
            obj.TakeDamage(currentDamage);
            ReducePierce();
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
            
}
