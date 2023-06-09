using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    Animator am;
    EnemyMovement em;
    EnemyAttackController at;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        em = GetComponent<EnemyMovement>();
        at = GetComponent<EnemyAttackController>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Note: Does not allow for turning atm. Must add direction checker
        if (at.isAttacking) { am.SetBool("Attack", true);  }
        else if (em.isMoving) { am.SetBool("Move", true); }
        else { am.SetBool("Move", false); }
    }

    // No direction checker atm as slime doesn't turn
    // void SpriteDirectionChecker() {}
}
