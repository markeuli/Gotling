using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    private Transform player;
    private Rigidbody2D body;

    public float range = 0.5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector2.Distance(player.position, body.position);
        if (distance <= range)
        {
        } else if (distance + enemyData.MoveSpeed * Time.fixedDeltaTime <= range) {
            body.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, distance - range));
        } else
        {
            body.MovePosition(Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.fixedDeltaTime));
        }
    }
}
