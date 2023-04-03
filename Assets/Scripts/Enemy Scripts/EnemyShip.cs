using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class EnemyShip : IMove, IRotation
{
    private readonly IMove _moveImplementation;
    private readonly IRotation _rotationImplementation;
    public float Speed => _moveImplementation.Speed;
    public EnemyShip(IMove moveImplementation, IRotation rotationImplementation)
    {
        _moveImplementation = moveImplementation;
        _rotationImplementation = rotationImplementation;
    }
    public void Move(Rigidbody2D rigidbody, float vertical, float deltaTime)
    {
        _moveImplementation.Move(rigidbody, vertical, deltaTime);
    }
    public void Rotation(Rigidbody2D rigidbody, float horizontal, float deltaTime)
    {
        _rotationImplementation.Rotation(rigidbody, horizontal, deltaTime);
    }
    public void AddAcceleration()
    {
        if (_moveImplementation is AccelerationMove accelerationMove)
        {
            accelerationMove.AddAcceleration();
        }
    }
    public void RemoveAcceleration()
    {
        if (_moveImplementation is AccelerationMove accelerationMove)
        {
            accelerationMove.RemoveAcceleration();
        }
    }
}
