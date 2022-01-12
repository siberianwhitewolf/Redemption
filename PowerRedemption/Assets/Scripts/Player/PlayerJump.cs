using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    bool _isJumping;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _isJumping = true;
        Player.playerRef.isOnFloor = _isJumping;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isJumping = false;
        Player.playerRef.isOnFloor = _isJumping;
    }
}
