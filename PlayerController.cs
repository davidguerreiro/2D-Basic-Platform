using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string[] toIgnore = new string[] {
        "invisible_wall",
    };

    // children gameObjects.
    private GameObject ceillingCheck;
    private BoxCollider2D otherBoxCollider2D;   // box collider used for ignore collisions.

    // called on the first frame.
    void Start()
    {
        ceillingCheck = transform.Find( "CeilingCheck" ).gameObject;
    }

    // player collsion enter controller.
    void OnCollisionEnter2D( Collision2D coll )
    {
        GameObject otherObject = coll.gameObject;
        /**
         * Player must stay and move withing moving platforms,
         * so when the playen enter a platform it becomes a child
         * of the platform itself so it moves to where the platform
         * moves.
         */
        if ( otherObject.tag == "moving_platform" ) {
            transform.parent = coll.transform;
        }

        // invisible walls do not affect player progression.
        if ( Array.IndexOf( toIgnore, otherObject.tag ) >  - 1 ) {
            GetColliderComponent( otherObject );
        }
    }

    // player collision stay controller.
    void OnCollisionStay2D( Collision2D coll )
    {
        if ( coll.gameObject.tag == "moving_platform" ) {
            transform.parent = coll.transform;
            
            // allow player to jump.
            if ( Input.GetKeyDown( KeyCode.Space ) ) {
                transform.parent = null;
            }
        }
    }

    // player collision exit controller.
    void OnCollisionExit2D( Collision2D coll )
    {
        if ( coll.gameObject.tag == "moving_platform" ) {
            transform.parent = null;
        }
    }

    // get collider component to ignore collisions based in that collider component.
    private void GetColliderComponent( GameObject other ) {

        // ignore collsion for invisible walls.
        if ( other.tag == "invisible_wall" ) {
            BoxCollider2D otherBoxCollider2D = other.GetComponent<BoxCollider2D>();

            if ( otherBoxCollider2D != null ) {
                IgnoreCollision( otherBoxCollider2D );
            }
        }
    } 

    // ignore collisions for BoxColliders2D.
    private void IgnoreCollision( BoxCollider2D otherCollider ) {
        Physics2D.IgnoreCollision( otherCollider, GetComponent<CircleCollider2D>() );
        Physics2D.IgnoreCollision( otherCollider, GetComponent<BoxCollider2D>() );
        Physics2D.IgnoreCollision( otherCollider, ceillingCheck.GetComponent<BoxCollider2D>() );
    }
    
}
