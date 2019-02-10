﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 3;
    private int healthLimit = 3;
    
    private string[] toIgnorePhysics = new string[] {
        "pick_me",
        "pick_me_red",
        "pick_me_blue",
    };

    private GameObject ceilingCheck;

    // Start is called before the first frame update
    void Start()
    {
        ceilingCheck = transform.Find( "CeilingCheck" ).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // setters and getters for health.
    public int GetHealth() {
        return this.health;
    }

    public void SetHealth( int health ) {
        this.health = health;
    }

    // method to damage player.
    public void playerIsDamaged() {
        this.health--;
    }

    public void playerRecoversLife( int toRecover ) {
        this.health += toRecover;

        if ( this.health > healthLimit ) {
            SetHealth( healthLimit );
        }
    }

}
