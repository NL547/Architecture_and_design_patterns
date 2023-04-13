using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroid
{
    internal sealed class EnemyShip : Enemy
    {
        [SerializeField] private float _speed;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _turnSpeed;

        public LayerMask targetMask;
        public LayerMask obstacleMask;

        public float viewRadius;
        [Range(0, 360)]
        public float viewAngle;
        public float attackDistance;

        //public List<Collider2D> visibleCollider = new List<Collider2D>();


        protected override void Start()
        {
            base.Start();
            
        }

        protected override void Update()
        {
            base.Update();
            RaycastHit2D[] targetColliders = Physics2D.CircleCastAll(transform.position, viewRadius, Vector2.zero, viewRadius, targetMask);

            for(int i = 0; i < targetColliders.Length; i++)
            {
                if (targetColliders[i].collider.gameObject.tag == "Player")
                {
                    float distance = Vector2.Distance(transform.position, targetColliders[i].collider.transform.position);
                    TurnToObject(targetColliders[i].collider.transform.position);
                    if (distance > attackDistance)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, targetColliders[i].collider.transform.position, _speed * Time.deltaTime);
                    }
                    else if (distance <= attackDistance)
                    {
                        Bullet temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                        temAmmunition.Shoot(_barrel.up);
                    }
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name == "laser")
            {
                currentHP -= other.gameObject.GetComponent<Bullet>().damage;
            }            
        }

        private void TurnToObject(Vector3 targetPos)
        {
            Vector3 direction = targetPos - transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z,
                (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f, _turnSpeed * Time.deltaTime)));
        }

        private void TurnFromObject(Vector3 targetPos)
        {
            Vector3 direction = targetPos - transform.position;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.LerpAngle(transform.rotation.eulerAngles.z,
                (Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg) - 90f, _turnSpeed * Time.deltaTime)));
        }
    }
}
