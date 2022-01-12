using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs
{
    public static Inputs inputsRef;

    Movement _movement;

    float h;
    float v;

    public Inputs(Movement movement)
    {
        inputsRef = this;

        _movement = movement;
    }

    public void OnFixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            _movement.Move(h, v);
        }
    }

    public void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _movement.Jump();
        }
    }
}
