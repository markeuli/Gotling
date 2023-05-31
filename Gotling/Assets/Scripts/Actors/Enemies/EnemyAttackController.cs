using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
	public WeaponController weapon;
	private float attackingUntil = 0;

	public bool isAttacking { get { return Time.time < attackingUntil; } }

	public float totalDelay { get { return weapon == null ? 0 : weapon.totalWeaponDelay; } }

	// Start is called before the first frame update
	void Start()
	{
	}

	public bool StartAttack(Vector2 direction)
	{
		if (!isAttacking && weapon != null)
		{
			StartCoroutine(ExecuteAttack(direction));
			attackingUntil = Time.time + weapon.totalWeaponDelay;
			return true;
		}
		return false;
	}

	private IEnumerator ExecuteAttack(Vector2 direction)
	{
		yield return new WaitForSeconds(weapon.weaponData.StartupDelay);
		if (weapon != null)
		{
			weapon.Attack(direction);
		}
	}
}
