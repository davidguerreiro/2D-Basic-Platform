using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitLevel : MonoBehaviour
{
    // Check if the player has reach the level limit boundary - if so, player is death.
    void OnCollisionEnter2D( Collision2D coll ) {
        GameObject objectCollided = coll.collider.gameObject;

        // any collision with player death tag gameobjects kills the player instantly.
        if ( objectCollided.tag == "Player" ) {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }
    
}
