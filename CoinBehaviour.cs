using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    // rotation speed.
    public float RotationSpeed = 3.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate( 0, RotationSpeed, 0 );
    }

}
