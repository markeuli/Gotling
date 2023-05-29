using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private Vector2 moveDir;
    private PlayerMovement movement;

	private void Start()
	{
		movement = GetComponent<PlayerMovement>();
	}

	private void Update()
	{
        InputManagment();
        movement.Move(moveDir);
	}

	// Start is called before the first frame update
	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.TryGetComponent(out iCollectable collectable))
        {
            collectable.Collect();
        }
    }

    void InputManagment()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        float fire1 = Input.GetAxisRaw("Fire1");
        float fire2 = Input.GetAxisRaw("Fire2");

        moveDir = new Vector2(moveX, moveY).normalized;
    }
}
