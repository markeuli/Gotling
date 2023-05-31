using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector2? target;
    private Rigidbody2D body;

    private float speed = 1;
    public bool isMoving { get; private set; }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target == null)
        {
            isMoving = false;
            return;
		} else
		{
            isMoving = true;
        }

        body.MovePosition(Vector2.MoveTowards(transform.position, target.Value, speed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 target, float speed = 1)
	{
        this.target = target;
        this.speed = speed;
	}

    public void Stop()
	{
        target = null;
        speed = 0;
	}
}
