using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelManager))]
public class LevelScaledDamageableObject : DamageableObject
{
	LevelManager levelManager;

	protected virtual void Start()
	{
		levelManager = GetComponent<LevelManager>();
	}

	public override void TakeDamage(float damage, GameObject source = null)
	{
		var sourceLevel = source?.GetComponent<LevelManager>();
		if (sourceLevel == null)
		{
			base.TakeDamage(damage, source);
		}
		else
		{
			base.TakeDamage(DamageFormula(sourceLevel.currentLevel, levelManager.currentLevel) * damage, source);
		}
	}

	private float DamageFormula(float source, float target)
	{
		return 1f + ((source - target) / 10f) * 0.1f;
	}
}
