using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimitLevel : MonoBehaviour
{
    private GameController gameController;              // used to add coins, lives, etc.
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
    }
    // Check if the player has reach the level limit boundary - if so, player is death.
    
    void OnCollisionEnter2D( Collision2D coll ) {
        GameObject objectCollided = coll.collider.gameObject;

        // any collision with player death tag gameobjects kills the player instantly.
        if ( objectCollided.tag == "Player" ) {
            gameController.PlayerKilled();
        }
    }
    
}
