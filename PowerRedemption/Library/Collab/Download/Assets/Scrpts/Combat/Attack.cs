using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Entity
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDmage(damage);
        }
    }
}
