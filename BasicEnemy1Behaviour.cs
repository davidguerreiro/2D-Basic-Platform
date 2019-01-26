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
        "soft_block",
        "solid_element",
        "invisible_wall",
    };

    private string[] toIgnore = new string[] {       // used to check which gameobjects are ignored by enemies, like coins.
        "pick_me"
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

    // children colliders.
    private GameObject KillerColliderRight;
    private GameObject KillerColliderLeft;
    private GameObject WeakPointCollider;
    
    // Start is called before the first frame update.
    void Start()
    {
        resetRotation();
        rigidbodyComponent = GetComponent<Rigidbody2D>();

        Debug.Log( orientation.GetType() );

        if ( canMove ) {
            moveEnemy( orientation );
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
        if ( Array.IndexOf( isSolid, objectCollider.tag ) > - 1  ) {
            speed *= - 1;
        }

        // check if the gameobject collided has to be ignored.
        if ( Array.IndexOf( toIgnore, coll.gameObject.tag ) > - 1 ) {
            IgnoreCollision( objectCollider );
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

    // ignore collisions in enemy collider and in children colliders.
    void IgnoreCollision( GameObject objectCollider ) {
        Physics2D.IgnoreCollision( objectCollider.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>() );
        Physics2D.IgnoreCollision( objectCollider.GetComponent<CircleCollider2D>(), KillerColliderRight.GetComponent<CircleCollider2D>() );
        Physics2D.IgnoreCollision( objectCollider.GetComponent<CircleCollider2D>(), KillerColliderLeft.GetComponent<CircleCollider2D>() );
        Physics2D.IgnoreCollision( objectCollider.GetComponent<CircleCollider2D>(), WeakPointCollider.GetComponent<PolygonCollider2D>() );
    }
    
}
