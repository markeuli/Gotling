using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
	public Action OnDeath;
	public bool isAlive { get; private set; }

	private float _currentHp;
	public float currentHp
	{
		get
		{
			return _currentHp;
		}
		set
		{
			_currentHp = value;
			CheckCurrent();
			Debug.Log("Current Hp of this damageable object is" + _currentHp);
		}
	}

	private float _maximumHp;
	public float maximumHp
	{
		get
		{
			return _maximumHp;
		}
		set
		{
			_maximumHp = Mathf.Max(value, 1); // Don't allow max HP below 1
			CheckCurrent();
		}
	}

	private void CheckCurrent()
	{
		_currentHp = Mathf.Min(_maximumHp, _currentHp); // Don't let HP go above maximum
		_currentHp = Mathf.Max(0, _currentHp); // Don't let HP fall below 0

		if (isAlive)
		{
			if (_currentHp <= 0)
			{
				if (OnDeath != null)
				{
					OnDeath();
				}
				isAlive = false;
			}
		} else
		{
			if (_currentHp > 0)
			{
				isAlive = true;
			}
		}
	}

	public virtual void TakeDamage(float damage, GameObject source = null)
	{
		currentHp -= damage;
	}

	public void Heal(float health)
	{
		currentHp += health;
	}

	public void SetMaximum(float maximum, bool grantCurrent)
	{
		var gained = Mathf.Max(maximum - _maximumHp, 0);
		_maximumHp = maximum;
		_currentHp += gained;
		if (_currentHp > 0)
		{
			isAlive = true;
		}
	}

}
