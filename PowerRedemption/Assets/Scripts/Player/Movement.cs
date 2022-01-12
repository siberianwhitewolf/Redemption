using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    Rigidbody2D _rigidbody;

    float _speed;
    float _jumpForce;

    public Movement(Rigidbody2D rigidbody, float speed, float jumpForce)
    {
        _rigidbody = rigidbody;

        _speed = speed;
        _jumpForce = jumpForce;
    }

    public void Move(float h, float v)
    {
        var vector = _rigidbody.transform.forward * v;
        vector += _rigidbody.transform.right * h;

        _rigidbody.transform.position += vector * _speed * Time.fixedDeltaTime;
    }

    public void Jump()
    {
        if (Player.playerRef.isOnFloor)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
