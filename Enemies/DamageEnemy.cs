using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    // Enter Collision controller.
    private GameObject parentEnemy;

    // Start is called before the first frame update.
    void Start()
    {
        parentEnemy = transform.parent.gameObject;
        Debug.Log( parentEnemy.GetComponent<BasicEnemy1Behaviour>().toIgnore );
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject objectCollider = other.gameObject;

    }
}
