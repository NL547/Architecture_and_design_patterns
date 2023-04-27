using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    public class Enemy : MonoBehaviour
    {
        public Rigidbody2D rigidbody;
        public int maxHP;
        public int currentHP;

        protected virtual void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            if (rigidbody == null) rigidbody = gameObject.AddComponent<Rigidbody2D>();
            rigidbody.gravityScale = 0;
        }

        protected virtual void Start()
        {
            currentHP = maxHP;
        }

        protected virtual void Update()
        {
            if (currentHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
