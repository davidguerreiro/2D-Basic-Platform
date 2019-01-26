using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
    int coins;
    int score;
    int lives = 3;

    // Check collisons with other objects
    void OnCollisionEnter2D( Collision2D coll ) {
        // get tag from the GameObject we have just collided.
        GameObject objectCollided = coll.collider.gameObject;

        // check if we are colliding a coin gameobject.
        if ( objectCollided.tag == "pick_me" || objectCollided.tag == "pick_me_red" || objectCollided.tag == "pick_me_blue" ) {
            // destroy the coin.
            Destroy( objectCollided );

            // red coins give 5 coins.
            if ( objectCollided.tag == "pick_me_red" ) {
                coins += 5;
            } else {
                coins++;
            }
            
            // add extra life to player when 100 coins are collected.
            if ( coins > 100 ) {
                lives++;
                coins = 0;
            }

            // add extra live when the player picks up a live.
            if ( objectCollided.tag == "pick_me_blue" ) {
                lives++;
            }

            print( "Lives : " + lives + " | Coins  : " + coins + " | Score : " + score );
        }

        // check if we are colliding a red ball so the Scene is restarted.
        if ( objectCollided.tag == "avoid_me" ) {
            // destroy the red ball and then reload the scene.
            Destroy( gameObject );
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }
}
