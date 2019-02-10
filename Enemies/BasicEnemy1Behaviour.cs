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
        "pick_me",
        "pick_me_red",
        "pick_me_blue",
        "enemy",
    };


    

    public int health = 1;  // enemys health - when 0 it is destroyed.
    public float speed = 60;   // enemy's horizontal speed.
    private string direction;
    public bool canMove = false;  // check if the enemy can move.
    private Rigidbody2D rigidbodyComponent; // Enemy gameObject RigiBody component.
    private CircleCollider2D otherCircleCollider; // Used for ignore Collision

    // children colliders.
    private GameObject KillerColliderRight;
    private GameObject KillerColliderLeft;
    private GameObject WeakPointCollider;
    private GameObject WeakPointColliderRight;

    private GameObject player;
    private Rigidbody2D player_RigiBody2D;
    
    // Start is called before the first frame update.
    void Start()
    {
        resetRotation();
        rigidbodyComponent = GetComponent<Rigidbody2D>();

        if ( canMove ) {
            moveEnemy();
        } else {
            ResetVelocity();
        }

        // get children colliders.
        KillerColliderRight = transform.Find( "KillColliderRight" ).gameObject;
        KillerColliderLeft  = transform.Find( "KillColliderLeft" ).gameObject;
        WeakPointCollider   = transform.Find( "WeakPointCollider" ).gameObject;
        WeakPointColliderRight = transform.Find( "WeakPointColliderRight" ).gameObject;

        // get player and player RigiBody component.
        player = GameObject.Find( "Player" );
        
        if ( player != null ) {
            player_RigiBody2D = player.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        resetRotation();

        if ( canMove ) {
            moveEnemy();
        } else {
            ResetVelocity();
        }
    }

    /**
     * enemy collsions controller - used only for movement
     * to see kill and defeat collisions please check children
     * gameObjects colliders.
     */
     void OnCollisionEnter2D( Collision2D coll ) {
        GameObject objectCollider = coll.gameObject;
        
        // flip enemy if you collide any kind of solid object ( like walls ).
        if ( Array.IndexOf( isSolid, objectCollider.tag ) > - 1  ) {
            speed *= - 1;
            Debug.Log( speed ); // TODO: Re-check children collisions because sometimes speed is not multiplied by -1.
        }

        // check if the gameobject collided has to be ignored.
        if ( Array.IndexOf( toIgnore, coll.gameObject.tag ) > - 1 ) {
            coll.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetColliderComponent( objectCollider );
        }

        // destroy enemy if it touchs a game over point.
        if ( objectCollider.tag == "player-death" ) {
            Destroy( this.gameObject );
        }
     }

     // exit collision for enemy1 controller.
     void OnCollisionExit2D( Collision2D other )
     {
        GameObject objectCollider = other.gameObject;
        // restore Dynamic body for collectibles after the enemy finish the collsion.
        if ( Array.IndexOf( toIgnore, other.gameObject.tag ) > - 1 ) {
            //other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
     }
     
    // this enemy is an sphere but does not rotate.
    private void resetRotation() {
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3( 0, 0, 0 );
        transform.rotation = q;
    }

    // move enemy on the x axis.
    private void moveEnemy() {

        if ( rigidbodyComponent != null ) {
            rigidbodyComponent.velocity = new Vector3( speed * Time.deltaTime, 0, 0 );
        }
    }

    // get collider compontent from collided object on collisions.
    private void GetColliderComponent( GameObject other ) {

        // ignore collisions for pick-up items.
        if ( other.tag == "pick_me" ) {
            CircleCollider2D otherCircleCollider = other.GetComponent<CircleCollider2D>();
            
            if ( otherCircleCollider != null ) {
                IgnoreCollision( otherCircleCollider );
            } 
        }

    }

    // ignore collisions with Circle Colliders in 2D controller.
    private void IgnoreCollision( CircleCollider2D otherCollider ) {
        Physics2D.IgnoreCollision( otherCollider, GetComponent<CircleCollider2D>() );
        Physics2D.IgnoreCollision( otherCollider, KillerColliderRight.GetComponent<CircleCollider2D>() );
        Physics2D.IgnoreCollision( otherCollider, KillerColliderLeft.GetComponent<CircleCollider2D>() );
        Physics2D.IgnoreCollision( otherCollider, WeakPointCollider.GetComponent<CircleCollider2D>() );
        Physics2D.IgnoreCollision( otherCollider, WeakPointColliderRight.GetComponent<CircleCollider2D>() );
    }

    // ensure the enemy is not moved by engine physics when canMove is enabled.
    private void ResetVelocity() {
        if ( rigidbodyComponent != null ) {
            rigidbodyComponent.velocity = new Vector3( 0, 0 , 0 );
        }
    }

    // this enemy is damaged.
    public void EnemyIsDamaged() {
        health--;

        if ( health <= 0 ) {
            EnemyIsDefeated();
        }
    }

    // enemy defeated.
    private void EnemyIsDefeated() {
        // TODO : Add force to player and animation to enemy.
        if ( player_RigiBody2D != null ) {
            player_RigiBody2D.AddForce( new Vector2( 0f, 600f ) );
            Destroy( this.gameObject ); 
        } else {
            Destroy( this.gameObject );
        }

    }


    
}
