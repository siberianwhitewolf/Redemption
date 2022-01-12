using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [Header("Configuration")]
    public float life;
    public float maxLife;

    private void Start()
    {
        maxLife = life;
    }

    public virtual void TakeDmage(float dmg)
    {
        life -= dmg;
        if (life <= 0)
        {
            life = 0;
            Death();
        }
    }

    public virtual void TakeLife(float hp)
    {
        if (life <= maxLife)
        {
            life += hp;
        }
    }

    public virtual void Death()
    {
        //Play Death animation
        Destroy(this.gameObject);
    }
}
