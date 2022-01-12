using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public float enemyDmage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var entity = collision.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            entity.TakeDmage(enemyDmage);
        }
    }
}
