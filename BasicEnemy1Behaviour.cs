using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy1Behaviour : MonoBehaviour
{
    private string[] isSolid = new string[] {       // used to check when the enemy collides solid objects so the enemy sprite is flipped.
        "soft_block",
        "solid_element",
    };

    public int health = 1;  // enemys health - when 0 it is destroyed.
    private bool m_FacingLeft = true;  // for determining which way the player is currently facing.
    
    // Start is called before the first frame update
    void Start()
    {
        resetRotation();
    }

    // Update is called once per frame
    void Update()
    {
        resetRotation();
    }

    /**
     * Control collisions on this enemy.
     * - Active/disable enemy when the player is in vision range.
     * - Kill the player when contact is made vertically and from the bottom.
     * - Be killed by the player when contact is made from above.
     * - Flip and change direction when a solid wall is touched.
     */
     void OnCollisionEnter2D( Collision2D coll )
     {
        // Debug.Log( coll.contacts[0] );
     }

     // this enemy is an sphere but does not rotate.
     private void resetRotation() {
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3( 0, 0, 0 );
        transform.rotation = q;
     }

     // flip enemy sprite.
     private void Flip() {
         // Switch the way the player is labelled as facing.
         m_FacingLeft = ! m_FacingLeft;

         // Multiply the player's x local scale y -1.
         Vector3 theScale = transform.localScale;
         theScale *= - 1;
         transform.localScale = theScale;
     }
}
