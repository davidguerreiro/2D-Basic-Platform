﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt( "coins", 0 );
        PlayerPrefs.SetInt( "score", 0 );
        PlayerPrefs.SetInt( "lifes", 3 );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
