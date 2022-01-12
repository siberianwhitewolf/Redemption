using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("Configuration")]
    public float speed;
    public float dashSpeed;
    public float startDashTime;
    public float jumpForce;
    public float checkRadius;
    public bool isGrounded;
    public LayerMask whatIsGround;

    [Header("Dependencies")]
    public Rigidbody2D rigidbody;
    public Transform feetPosition;
    public SpriteRenderer sprite;

    //Private
    private Vector2 _movementInput;
    private bool _isAttacking;
    private float _dashTime;
    private float _baseSpeed;
    private bool _isDashing = false;

    private void Start()
    {
        _dashTime = startDashTime;
        _baseSpeed = speed;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(_movementInput.normalized.x * speed, rigidbody.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);

        
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        _movementInput = value.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.performed && isGrounded)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            this.gameObject.GetComponent<Entity>().TakeDmage(20f);
        }

    }

    public void OnDash(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            if (!_isDashing && isGrounded)
            {
                StartCoroutine(Dash());
            }
        }
    }

    IEnumerator Dash()
    {
        _isDashing = true;
        speed = dashSpeed;
        yield return new WaitForSeconds(_dashTime);
        speed = _baseSpeed;
        _isDashing = false;
    }


    private void OnDrawGizmosSelected()
    {
        if (feetPosition == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawWireSphere(feetPosition.position, checkRadius);
        }
    }

}
