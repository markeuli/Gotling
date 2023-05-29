using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour

{
    public WeaponScriptableObject weaponData;
   
    float currentCooldown;
    protected PlayerMovement pm;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.CooldownDuration;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f)
        {
            Attack();
        }
    }

    // Put the attack on cooldown
    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}
