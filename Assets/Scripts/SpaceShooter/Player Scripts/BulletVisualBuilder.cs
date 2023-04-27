using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class BulletVisualBuilder : BulletBuilder
{
    public BulletVisualBuilder(GameObject gameObject) : base(gameObject)
    { }
    public BulletVisualBuilder Name(string name)
    {
        _bullet.name = name;
        return this;
    }
    public BulletVisualBuilder Sprite(Sprite sprite)
    {
        var component = GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
        return this;
    }
    private T GetOrAddComponent<T>() where T : Component
    {
        var result = _bullet.GetComponent<T>();
        if (!result)
        {
            result = _bullet.AddComponent<T>();
        }
        return result;
    }
}
