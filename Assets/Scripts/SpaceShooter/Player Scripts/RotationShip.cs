using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class RotationShip : IRotation
{
    public float Speed { get; }

    public RotationShip(float speed)
    {
        Speed = speed;
    }
    public void Rotation(Rigidbody2D rigidbody, float horizontal, float deltaTime)
    {
        float turnDirection = horizontal * Speed * deltaTime * -1f;
        rigidbody.AddTorque(turnDirection);
    }
}
