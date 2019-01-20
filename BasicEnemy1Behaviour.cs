using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy1Behaviour : MonoBehaviour
{
    private string[] isSolid = new string[] {
        "soft_block",
        "solid_element",
    };

    public int health = 1;
    
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
        Debug.Log( coll.contacts[0] );
     }

     // this enemy is an sphere but does not rotate.
     private void resetRotation() {
        Quaternion q = transform.rotation;
        q.eulerAngles = new Vector3( 0, 0, 0 );
        transform.rotation = q;
     }
}
