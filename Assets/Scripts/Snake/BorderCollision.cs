using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Border")
        {
            Debug.LogError("Game over!");
            Destroy(transform.gameObject);
        }
    }
}
