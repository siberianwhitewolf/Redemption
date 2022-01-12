using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{

    [Header("Configuration")]
    public float attackRange;
    public float attackDamage = 1;

    [Header("Dependencies")]
    public Transform attackPoint;
    public LayerMask enemyLayers;


    public void Attack(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit enemy");
                enemy.GetComponent<Enemy>().TakeDmage(attackDamage);
            }
        }

    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }

}

