using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    // rotation speed.
    public float RotationSpeed = 3.5f;
    private string[] toIgnore = new string[] {       // used to check when the enemy collides solid objects so the enemy sprite is flipped.
        "enemy"
    };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( 0, RotationSpeed, 0 );
    }

}
