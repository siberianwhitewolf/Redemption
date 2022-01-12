using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Entity
{

    public override void TakeDmage(float dmg)
    {
        base.TakeDmage(dmg);
    }

    public override void Death()
    {
        Destroy(gameObject);
    }
}
