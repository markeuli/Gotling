using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
	public Action OnDeath;
	public HealthChangeEvent OnHealthChange;
	public DamageTakenEvent OnDamageTaken;
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
			var prev = currentHp;
			_currentHp = value;
			CheckCurrent();
			if (OnHealthChange != null && prev != currentHp)
			{
				OnHealthChange(currentHp, maximumHp);
			}
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
			var prev = _maximumHp;
			_maximumHp = Mathf.Max(value, 1); // Don't allow max HP below 1
			CheckCurrent();
			if (OnHealthChange != null && prev != maximumHp)
			{
				OnHealthChange(currentHp, maximumHp);
			}
		}
	}

    

    private void CheckCurrent()
	{
		_currentHp = Mathf.Min(_maximumHp, currentHp); // Don't let HP go above maximum
		_currentHp = Mathf.Max(0, currentHp); // Don't let HP fall below 0
	}

	public virtual void TakeDamage(float damage, GameObject source = null)
	{
		if (OnDamageTaken != null)
		{
			damage = OnDamageTaken(damage, source);
		}

		currentHp -= damage;

		if (isAlive)
		{
			if (currentHp <= 0)
			{
				if (OnDeath != null)
				{
					OnDeath();
				}
				isAlive = false;
			}
		}
		else
		{
			if (currentHp > 0)
			{
				isAlive = true;
			}
		}
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
		if (currentHp > 0)
		{
			isAlive = true;
		}
	}

	public delegate float DamageTakenEvent(float damage, GameObject source);
	public delegate void HealthChangeEvent(float health, float max);
}
