using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // player collsion enter controller.
    void OnCollisionEnter2D( Collision2D coll )
    {
        if ( coll.gameObject.tag == "moving_platform" ) {
            transform.parent = coll.transform;
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
    
}
