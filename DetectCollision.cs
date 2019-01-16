using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
    int score;

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
        if ( objectCollided.tag == "pick_me" || objectCollided.tag == "pick_me_red" ) {
            // destroy the coin.
            Destroy( objectCollided );

            // red coins give 5 coins.
            if ( objectCollided.tag == "pick_me_red" ) {
                score += 5;
            } else {
                score++;
            }
            
            // add extra life to player when 100 coins are collected.
            if ( score > 100 ) {
                // add life to player here.
                score = 0;
            }
            print( "Score : " + score );
        }

        // check if we are colliding a red ball so the Scene is restarted.
        if ( objectCollided.tag == "avoid_me" ) {
            // destroy the red ball and then reload the scene.
            Destroy( objectCollided );
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }
}
