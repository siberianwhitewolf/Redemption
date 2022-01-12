using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

    [Header("Dependencies")]
    public Animator animator;
    public PlayerController controller;
    public float longIdleTime = 5f;


    //Private
    private bool _isAttacking;
    private float _longIdleTimer;

    public void OnMovement(InputAction.CallbackContext value)
    {
        float movementInput = value.ReadValue<Vector2>().magnitude;
        if(movementInput > 0f)
        {
            animator.SetBool("Idle", false);
        }

        else
        {
            animator.SetBool("Idle", true);
        }

    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if(value.performed && _isAttacking == false)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void LateUpdate()
    {
        animator.SetBool("IsGrounded", controller.isGrounded);
        animator.SetFloat("VerticalVelocity", controller.rigidbody.velocity.y);

        //Long Idle
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            _longIdleTimer += Time.deltaTime;
            if(_longIdleTimer >= longIdleTime)
            {
                animator.SetTrigger("LongIdle");
            }
        }
        else { _longIdleTimer = 0f; }

        //Attack
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;
        }


    }

}
