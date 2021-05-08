using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    // Destroying lasers that enter the trigger. Note: Collision will not be
    // detected unless collider is assigned to the game object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
