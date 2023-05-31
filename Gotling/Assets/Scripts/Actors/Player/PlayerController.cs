using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerMovement movement;
	public PlayerWeaponManager weapons;
	private DamageableObject damage;

	private void Start()
	{
		movement = GetComponent<PlayerMovement>();
		weapons = GetComponent<PlayerWeaponManager>();
		damage = GetComponent<DamageableObject>();

		damage.OnDeath += () => Debug.Log("Player dead");
	}

	private void Update()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");
		bool fire1 = Input.GetButton("Fire1");
		bool fire2 = Input.GetButton("Fire2");
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		movement.Move(new Vector2(moveX, moveY).normalized);

		// Fire weapon if hit
		if (fire1)
		{
			if (weapons.primary != null)
			{
				weapons.primary.Attack(mousePosition);
			}
		}

		// Fire weapon if hit
		if (fire2)
		{
			if (weapons.secondary != null)
			{
				weapons.secondary.Attack(mousePosition);
			}
		}
	}
}
