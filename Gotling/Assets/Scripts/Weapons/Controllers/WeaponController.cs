using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour

{
    public WeaponScriptableObject weaponData;
    public Team team = Team.Player;
    float currentCooldown = 0;
    protected PlayerMovement pm;

    public float totalWeaponDelay { get { return weaponData.StartupDelay + weaponData.EndingDelay; } }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        
    }

    // Put the attack on cooldown
    public virtual bool Attack(Vector2 direction)
    {
        if (Time.time >= currentCooldown)
        {
            currentCooldown = Time.time + weaponData.CooldownDuration;
            return true;
        }
        return false;
    }
}
