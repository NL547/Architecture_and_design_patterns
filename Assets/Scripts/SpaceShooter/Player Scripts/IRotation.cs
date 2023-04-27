using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotation
{
    void Rotation(Rigidbody2D rigidbody, float horizontal, float deltaTime);
}
