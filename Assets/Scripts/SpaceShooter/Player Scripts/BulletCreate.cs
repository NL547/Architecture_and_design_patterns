using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class BulletCreate : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    private void Start()
    {
        var gameObjectBuilder = new BulletBuilder();
        GameObject player = gameObjectBuilder.Visual.Name("Laser").Sprite(_sprite).Physics.Rigidbody2D(5).BoxCollider2D();
    }
}
