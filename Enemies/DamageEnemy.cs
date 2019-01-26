using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    // Enter Collision controller.
    private GameObject parentEnemy;
    private string[] toIgnore;

    // Start is called before the first frame update.
    void Start()
    {
        parentEnemy = transform.parent.gameObject;
        toIgnore    = parentEnemy.GetComponent<BasicEnemy1Behaviour>().toIgnore;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject objectCollider = other.gameObject;

        
    }
}
