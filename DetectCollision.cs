using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check collisons with other objects
    void OnCollisionEnter2D( Collision2D coll ) {
        // get tag from the GameObject we have just collided.
        GameObject objectCollided = coll.collider.gameObject;

        // check if we are colliding a coin gameobject.
        if ( objectCollided.tag == "pick_me" ) {
            // destroy the coin.
            Destroy( objectCollided );
        }
    }
}
