﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy1Behaviour : MonoBehaviour
{
    /**
     * Control collisions on this enemy. ( Delegated in children object colliders )
     * - Active/disable enemy when the player is in vision range.
     * - Kill the player when contact is made vertically and from the bottom.
     * - Be killed by the player when contact is made from above.
     * - Flip and change direction when a solid wall is touched.
     */

    private string[] isSolid = new string[] {       // used to check when the enemy collides solid objects so the enemy sprite is flipped.
        "soft_block",
        "solid_element",
        "invisible_wall",
    };

    

    public int health = 1;  // enemys health - when 0 it is destroyed.
    public float speed = - 8f;   // enemy's horizontal speed.
    public enum Orientation
    {
        Right,
        Left,
    };

    public Orientation orientation;
    public bool canMove = true;  // check if the enemy can move.
    private Rigidbody2D rigidbodyComponent; // Enemy gameObject RigiBody component.
    
    // Start is called before the first frame update.
    void Start()
    {
        resetRotation();
        rigidbodyComponent = GetComponent<Rigidbody2D>();

        Debug.Log( orientation.GetType() );

        if ( canMove ) {
            moveEnemy( orientation );
        }
    }

    // Update is called once per frame
    void Update()
    {
        resetRotation();

        if ( canMove ) {
            moveEnemy( orientation );
        }
    }

    /**
     * enemy collsions controller - used only for movement
     * to see kill and defeat collisions please check children
     * gameObjects colliders.
     * 
     * Move this collision to children gameObject.
     */
     void OnCollisionEnter2D( Collision2D coll ) {
        GameObject objectCollider = coll.gameObject;
        
        // flip enemy if you collide any kind of solid object ( like walls ).
        if ( Array.IndexOf( isSolid, coll.gameObject.tag ) > - 1  ) {
            speed *= - 1;
        }
     }
    // this enemy is an sphere but does not rotate.
    private void resetRotation() {
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3( 0, 0, 0 );
        transform.rotation = q;
    }

    // move enemy on the x axis.
    void moveEnemy( Orientation orientation ) {

        // fix and set enemy orientation.
        string direction = orientation.ToString();

        if (  ( direction == "Right" && speed < 0 ) || ( direction == "Left" && speed > 0 ) ) {
            speed *= - 1;
        }

        if ( rigidbodyComponent != null ) {
            rigidbodyComponent.velocity = new Vector3( speed * Time.deltaTime, 0, 0 );
        }
    }
    
}
