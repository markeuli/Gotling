using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector2 direction;
    public float destroyAfterSeconds;

    //CurrentStats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;

    protected Rigidbody2D body;

    protected virtual void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
    }

    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    private void SetTeam(Team team)
	{
		switch (team)
		{
			case Team.Player:
                gameObject.layer = LayerMask.NameToLayer("PlayerProjectiles");
				break;
			case Team.Enemy:
                gameObject.layer = LayerMask.NameToLayer("EnemyProjectiles");
                break;
			default:
                gameObject.layer = LayerMask.NameToLayer("NeutralProjectiles");
                break;
		}
	}

    public virtual void SetupProjectile(Vector3 dir, Team team = Team.Player)
    {
        direction = dir;
        body = GetComponent<Rigidbody2D>();
        
        transform.right = -dir;
        SetTeam(team);
    }
            
}
