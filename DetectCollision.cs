using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollision : MonoBehaviour
{
    private int coins;
    private int score;
    private int lives;

    private string[] giveCoins = new string[] {
        "pick_me",
        "pick_me_red",
    };

    private GameController gameController;              // used to add coins, lives, etc.
    private Rigidbody2D player_RigiBody;                // player rigibody used to alter player physics.

    // called on the very first frame.
    void Start() {
        // get game controller script to modify game logic.
        gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
        player_RigiBody = GameObject.Find( "Player" ).GetComponent<Rigidbody2D>();
        coins = gameController.GetCoins();
        lives = gameController.GetLives();
        score = gameController.GetScore();
    }

    // called on every frame.
    void Update() {

    }

    // update values from GameController gameObject.
    void UpdateGameData() {
        coins = gameController.GetCoins();
        lives = gameController.GetLives();
        score = gameController.GetScore();
    }

    // Check collisons with other objects
    void OnCollisionEnter2D( Collision2D coll ) {
        // get tag from the GameObject we have just collided.
        GameObject objectCollided = coll.collider.gameObject;

        // check if we are colliding a coin gameobject.
        if ( objectCollided.tag == "pick_me" || objectCollided.tag == "pick_me_red" || objectCollided.tag == "pick_me_blue" ) {
            // get current game data values.
            UpdateGameData();
            /**
             * Destroy object collected - TODO: Remove physycis from coin
             * so player is not stopped by the collected object on collision.
             */
            print( "here collision" );

            if ( objectCollided.tag == "pick_me" ) {
                gameController.AddCoin();
            }

            // red coins give 5 coins.
            if ( objectCollided.tag == "pick_me_red" ) {
                coins += 5;
                gameController.SetCoins( coins );
            } 
            
            // add extra life to player when 100 coins are collected.
            if ( ( Array.IndexOf( giveCoins, objectCollided.tag ) > - 1 ) && coins >= 100 ) {
                gameController.AddLifeFromCoins();
            }

            // add extra live when the player picks up a live.
            if ( objectCollided.tag == "pick_me_blue" ) {
                gameController.AddLife();
            }

            Destroy( objectCollided );
        }

        // check if we are colliding a damaging item and if so, game over for now.
        if ( objectCollided.tag == "avoid_me" ) {
            gameController.GameOver();
        }
    }
}
