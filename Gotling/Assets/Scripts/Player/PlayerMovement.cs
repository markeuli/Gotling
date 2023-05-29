using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 lastMovedVector { get; private set; }
    public bool isMoving { get; private set; }

    //References
    Rigidbody2D rb;
    public CharacterScriptableObject characterData;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(Vector2 dir)
    {
        if (dir != Vector2.zero)
		{
            lastMovedVector = dir;
            isMoving = true;
        } else
		{
            isMoving = false;
		}
        rb.velocity = new Vector2(dir.x * characterData.MoveSpeed, dir.y * characterData.MoveSpeed);
    }
}
