using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Entity
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity = collision.GetComponent<Entity>();
        if (entity != null)
        {
            entity.TakeDmage(2);
        }
    }

    public override void TakeDmage(float dmg)
    {
        base.TakeDmage(dmg);
    }

    public override void Death()
    {
        this.gameObject.SetActive(false);
    }
}
