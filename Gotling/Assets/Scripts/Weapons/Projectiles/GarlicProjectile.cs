using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicProjectile : MeleeProjectileBase
{
    List<GameObject> markedEnemies;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject> ();
    }    
}
