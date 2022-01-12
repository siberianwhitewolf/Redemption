using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRenderer : MonoBehaviour
{
    [Header("Configuration")]
    public float attackPointXOffset; //This value needs to be the same as the Transform position X value of the attackPoint as appears on the editor.

    [Header("Dependencies")]
    public SpriteRenderer sprite;
    public Transform attackPoint;
   

    public void OnMovement(InputAction.CallbackContext value)
    {
        if (value.performed) { 
        Vector2 movementInput = value.ReadValue<Vector2>();
        if (value.performed) { 
        if (movementInput.x > 0f && PlayerIsLookingLeft()) // Moving to the right
        {
            sprite.flipX = false;
            attackPoint.transform.position = new Vector2(sprite.transform.position.x + attackPointXOffset, attackPoint.transform.position.y); 
            }
        else if (movementInput.x < 0f && !PlayerIsLookingLeft()) // Moving to the left
        {
                sprite.flipX = true;
                attackPoint.transform.position = new Vector2(sprite.transform.position.x - attackPointXOffset, attackPoint.transform.position.y);
                }
        }
        }
    }


    private bool PlayerIsLookingLeft()
    {
        return sprite.flipX;
    }
}

