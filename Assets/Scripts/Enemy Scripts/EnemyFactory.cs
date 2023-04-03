using Asteroid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyFactory
{
    public static Enemy CreateEnemy()
    {
        return new Enemy();
    }
}
