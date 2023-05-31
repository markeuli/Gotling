using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // References
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;



    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponentInParent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.isMoving)
        {
            am.SetBool("Move", true);

            SpriteDirectionChecker();
        }
        else
        {
            am.SetBool("Move", false);
        }
    }
    void SpriteDirectionChecker()
    {
        if (pm.lastMovedVector.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}

