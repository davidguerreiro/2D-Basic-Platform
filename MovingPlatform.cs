using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log( "Platform Y : " + transform.position.y );
        //Debug.Log( "Platform X : " + transform.position.x );
    }

    // check collisions with other players.
    void OnCollisionEnter2D( Collision2D item )
    {
        GameObject objectCollided = item.collider.gameObject;

        Debug.Log( objectCollided.tag );

        // set player at same height as the platform.
        if ( objectCollided.tag == "Player" ) {
            Transform playerTransform  = objectCollided.GetComponent<Transform>();
            Vector3 temp = new Vector3( playerTransform.position.x, transform.position.y, playerTransform.position.z );
            playerTransform.transform.position += temp;
            

            Debug.Log( "Platform position : "  + transform.position.y );
            Debug.Log( "Player position : " + objectCollided.GetComponent<Transform>().position.y );

        }
    }


}
