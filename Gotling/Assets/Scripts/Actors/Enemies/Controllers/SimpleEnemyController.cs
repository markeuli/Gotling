using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyController : EnemyControllerBase
{
	protected override void Start()
	{
		base.Start();

        // Kill enemy instantly
        damage.OnDeath += () => Destroy(gameObject);
    }

	// Update is called once per frame
	protected override void Update()
    {
        base.Update();

        if (!isActing) {
            var distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance <= data.Range + 0.1f)
            {
                if (!isActing && !attacks.isAttacking)
                {
                    // Attempt exclusive access
                    if (TakeAction(attacks.totalDelay, true))
                    {
                        // Attack
                        attacks.StartAttack(player.transform.position);
                    }
                }
            }
            else
            {
                // Set the movement target to {range} distance away from the player
                movement.MoveTo(Vector2.MoveTowards(player.transform.position, transform.position, data.Range), data.MoveSpeed);
            }
        }
    }
}
