using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    // Update is called once per frame
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        DamagePlayer(col.gameObject);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        DamagePlayer(col.gameObject);
    }

    private void DamagePlayer(GameObject gameObject)
    {
        PlayerStats player = gameObject.GetComponent<PlayerStats>();
        if (player != null)
        {
            player.TakeDamage(currentDamage);
        }
    }
}
