using System;
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
        "is_solid_wall",
        "invisible_wall",
    };

    public string[] toIgnore = new string[] {       // used to check which gameobjects are ignored by enemies, like coins.
        "pick_me"
    };


    

    public int health = 1;  // enemys health - when 0 it is destroyed.
    public float speed = 60;   // enemy's horizontal speed.
    private string direction;
    public bool canMove = true;  // check if the enemy can move.
    private Rigidbody2D rigidbodyComponent; // Enemy gameObject RigiBody component.

    // children colliders.
    private GameObject KillerColliderRight;
    private GameObject KillerColliderLeft;
    private GameObject WeakPointCollider;
    
    // Start is called before the first frame update.
    void Start()
    {
        resetRotation();
        rigidbodyComponent = GetComponent<Rigidbody2D>();

        if ( canMove ) {
            moveEnemy();
        }

        // get children colliders.
        KillerColliderRight = transform.Find( "KillColliderRight" ).gameObject;
        KillerColliderLeft  = transform.Find( "KillColliderLeft" ).gameObject;
        WeakPointCollider   = transform.Find( "WeakPointCollider" ).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        resetRotation();
        Debug.Log( speed );

        if ( canMove ) {
            moveEnemy();
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
        if ( Array.IndexOf( isSolid, objectCollider.tag ) > - 1  ) {
            speed *= - 1;
        }

        // check if the gameobject collided has to be ignored.
        if ( Array.IndexOf( toIgnore, coll.gameObject.tag ) > - 1 ) {
           IgnoreCollision( objectCollider );
        }

        // destroy enemy if it touchs a game over point.
        if ( objectCollider.tag == "player-death" ) {
            Destroy( this.gameObject );
        }
     }
    // this enemy is an sphere but does not rotate.
    private void resetRotation() {
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3( 0, 0, 0 );
        transform.rotation = q;
    }

    // move enemy on the x axis.
    void moveEnemy() {

        if ( rigidbodyComponent != null ) {
            rigidbodyComponent.velocity = new Vector3( speed * Time.deltaTime, 0, 0 );
        }
    }

    // ignore collisions in enemy collider and in children colliders.
    public void IgnoreCollision( GameObject other ) {

        // ignore collisions for pick-up items.
        if ( other.tag == "pick_me" ) {
            CircleCollider2D otherCollider = other.GetComponent<CircleCollider2D>();

            Physics2D.IgnoreCollision( otherCollider, GetComponent<CircleCollider2D>() );
            Physics2D.IgnoreCollision( otherCollider, KillerColliderRight.GetComponent<CircleCollider2D>() );
            Physics2D.IgnoreCollision( otherCollider, KillerColliderLeft.GetComponent<CircleCollider2D>() );
            Physics2D.IgnoreCollision( otherCollider, WeakPointCollider.GetComponent<PolygonCollider2D>() );
        }
    }
    
}
