using Asteroid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Bullet
{
    [SerializeField] private Bullet _enemyBullet;
    [SerializeField] private Transform _enemyBarrel;

    public void Attack()
    {
        Bullet temAmmunition = Instantiate(_enemyBullet, _enemyBarrel.position, _enemyBarrel.rotation);
        temAmmunition.Shoot(_enemyBarrel.up);
    }
}
