using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    public class Enemy : EnemyVision
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _turnSpeed;
        private Rigidbody2D _rigidbody;
        private EnemyShip _enemyShip;
        private EnemyVision _enemyVision;
        private EnemyAttack _enemyAttack;

        private void Start()
        {
            var moveTransform = new AccelerationMove(transform, _speed,
            _acceleration);
            var rotation = new RotationShip(_turnSpeed);
            _enemyShip = new EnemyShip(moveTransform, rotation);
            _rigidbody = GetComponent<Rigidbody2D>();
            _enemyVision = gameObject.AddComponent<EnemyVision>();
            _enemyAttack = gameObject.AddComponent<EnemyAttack>();
        }
        private void Update()
        {

        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }
    }
}
