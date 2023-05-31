using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyControllerBase : MonoBehaviour
{
	protected EnemyMovement movement;
	protected PlayerController player;
	protected EnemyAttackController attacks;
	protected DamageableObject damage;
	public EnemyScriptableObject data;

	public bool isActing { get; private set; }
	protected float actingDelay = 0;

	// Start is called before the first frame update
	protected virtual void Start()
	{
		movement = GetComponent<EnemyMovement>();
		player = FindObjectOfType<PlayerController>();
		attacks = GetComponent<EnemyAttackController>();
		damage = GetComponent<DamageableObject>();

		damage.SetMaximum(data.MaxHealth, true);
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		if (actingDelay <= Time.time)
		{
			isActing = false;
		}
	}

	protected bool TakeAction(float delay, bool stop = false)
	{
		if (isActing)
		{
			return false;
		}

		// stop player movement
		if (stop)
		{
			movement.Stop();
		}
		actingDelay = Time.time + delay;
		isActing = true;

		return true;
	}
}
