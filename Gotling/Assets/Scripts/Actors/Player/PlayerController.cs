using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private PlayerMovement movement;
	public PlayerWeaponManager weapons;
	private DamageableObject damage;
	public PauseController _pauseController;

	private void Start()
	{
		movement = GetComponent<PlayerMovement>();
		weapons = GetComponent<PlayerWeaponManager>();
		damage = GetComponent<DamageableObject>();
		_pauseController = GameObject.Find("PauseController").GetComponent<PauseController>();

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

		if (!PauseController.isPaused)
		{
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

		if (Input.GetKeyDown(KeyCode.P))
		{
			_pauseController.TogglePause("PlayerPause");
		}
	}
}
