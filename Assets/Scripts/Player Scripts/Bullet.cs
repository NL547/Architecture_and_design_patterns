using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    public class Bullet : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        [SerializeField] float speed = 500;
        [SerializeField] public int damage = 10;

        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }        

        void Update()
        {
            
        }

        public void Shoot(Vector2 direction)
        {
            rigidbody.AddForce(direction * speed);
            Destroy(gameObject, 3f);
        }
    }
}
