using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement


    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDir;
    [HideInInspector]
    public Vector2 lastMovedVector;
    public KnifeController primaryWeapon;

    //References
    Rigidbody2D rb;
    public CharacterScriptableObject characterData;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f);
        primaryWeapon = GetComponentInChildren<KnifeController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManagment();
    }
    void FixedUpdate()
    {
        Move();
    }
    void InputManagment()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }
        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }
        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            primaryWeapon.Attack(mousePosition);
        }

    }
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * characterData.MoveSpeed, moveDir.y * characterData.MoveSpeed);
    }
}
