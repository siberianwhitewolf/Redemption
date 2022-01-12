using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player playerRef;

    Rigidbody2D _rigidbody;

    Inputs _inputs;
    Movement _movement;

    public float speed;
    public float jumpForce;
    public bool isOnFloor;

    public void Awake()
    {
        playerRef = this;

        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        _movement = new Movement(_rigidbody, speed, jumpForce);
        _inputs = new Inputs(_movement);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _inputs.OnFixedUpdate();
    }
}
