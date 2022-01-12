using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var entity = collision.gameObject.GetComponent<Entity>();
        if (collision.gameObject.layer == 8)
        {
            entity.TakeDmage(damage);
        }
    }

    public override void TakeDmage(float dmg)
    {
        base.TakeDmage(dmg);
    }

    public override void Death()
    {
        Destroy(gameObject);
    }
   

}
