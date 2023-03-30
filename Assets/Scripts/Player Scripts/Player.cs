using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _turnSpeed;
        private Rigidbody2D _rigidbody;
        private Camera _camera;
        private Ship _ship;

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed,
            _acceleration);
            var rotation = new RotationShip(_turnSpeed);
            _ship = new Ship(moveTransform, rotation);
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            //Vector3 trans = _camera.WorldToScreenPoint(transform.position);
           
            //Vector3 direction = Input.mousePosition - new Vector3(trans.y, trans.x, trans.z);
            _ship.Rotation(_rigidbody, Input.GetAxis("Horizontal"), Time.deltaTime);
            _ship.Move(_rigidbody, Input.GetAxis("Vertical"), Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                Bullet temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);                
                temAmmunition.Shoot(_barrel.up);
            }
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


