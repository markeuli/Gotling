using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public Action OnLevelUp;

	private float _currentLevel;
	public float currentLevel
	{
		get
		{
			return _currentLevel;
		}
		set
		{
			value = Mathf.Clamp(value, 0, maxLevel);

			if (value > _currentLevel)
			{
				while (value > _currentLevel)
				{
					// go up a level
					_currentLevel++;
					if (OnLevelUp != null)
					{
						// fire level up event
						OnLevelUp();
					}
				}
			} else
			{
				_currentLevel = value;
			}
		}
	}

	private float _maxLevel;
	public float maxLevel
	{
		get
		{
			return _maxLevel;
		}
		set
		{
			_maxLevel = Mathf.Max(value, 1); // Don't allow max level below 1
		}
	}

	public void LevelUp()
	{
		_currentLevel++;
		if (OnLevelUp != null)
		{
			// fire level up event
			OnLevelUp();
		}
	}

	public void SetStartingLevel(float level, float maximum = 0)
	{
		if (maximum > 0)
		{
			_maxLevel = Mathf.Max(maximum, level);
		} else
		{
			_maxLevel = level;
		}
		_currentLevel = level;
	}
}
