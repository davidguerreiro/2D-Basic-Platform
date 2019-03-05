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
    private GameObject player;                          // player gameObject.
    private Rigidbody2D player_RigiBody;                // player rigibody used to alter player physics.
    private AudioSource audioSource;                    // Player sound effects audioSource.

    public AudioClip collectSimpleCoin;                 // collect simple coin sound clip.
    public AudioClip collectRedCoin;                    // collect red coin sound clip.
    public AudioClip collectLife;                       // collect a live sound clip.
    public AudioClip die;                               // die sound clip.

    // called on the very first frame.
    void Start() {
        // get game controller script to modify game logic.
        gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
        player = GameObject.Find( "Player" );
        audioSource = GetComponent<AudioSource>();
        
        // get component from player if player exists.
        if ( player != null ) {
            player_RigiBody = player.GetComponent<Rigidbody2D>();
        }
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

            if ( objectCollided.tag == "pick_me" ) {
                audioSource.clip = collectSimpleCoin;
                audioSource.Play();
                gameController.AddCoin();
            }

            // red coins give 5 coins.
            if ( objectCollided.tag == "pick_me_red" ) {
                audioSource.clip = collectRedCoin;
                audioSource.Play();
                coins += 5;
                gameController.SetCoins( coins );
            } 
            
            // add extra life to player when 100 coins are collected.
            if ( ( Array.IndexOf( giveCoins, objectCollided.tag ) > - 1 ) && coins >= 100 ) {
                audioSource.clip = collectLife;
                audioSource.Play();
                gameController.AddLifeFromCoins();
            }

            // add extra live when the player picks up a live.
            if ( objectCollided.tag == "pick_me_blue" ) {
                audioSource.clip = collectLife;
                audioSource.Play();
                gameController.AddLife();
            }

            Destroy( objectCollided );
        }

        // check if we are colliding a damaging item and if so, game over for now.
        if ( objectCollided.tag == "avoid_me" ) {
            audioSource.clip = die;
            audioSource.Play();
            // player.SetActive( false );
            Destroy(player);
            gameController.PlayerKilled();
        }
    }
}
