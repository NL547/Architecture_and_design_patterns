using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class BulletBuilder : MonoBehaviour
{
    protected GameObject _bullet;

    public BulletBuilder() => _bullet = new GameObject();
    protected BulletBuilder(GameObject bullet) => _bullet = gameObject;

    public BulletVisualBuilder Visual => new BulletVisualBuilder(_bullet);

    public BulletPhysicsBuilder Physics => new BulletPhysicsBuilder(_bullet);

    public static implicit operator GameObject(BulletBuilder builder)
    {
        return builder._bullet;
    }
}
