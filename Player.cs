using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int health = 3;              // Player health. Not used in current version.
    public float fadeSpeed = 8f;       // Speed used for death animation.
    public bool canMove = false;        // Whether the player can move or not.
    public bool isDying = false;        // Wheter the player is being destroyed. Used to ensure control animation is only triggered once.
    private int healthLimit = 3;        // Player maximun health value. Not used in current version.
    private SpriteRenderer renderer;    // Player Sprite renderer component.
    
    
    private string[] toIgnorePhysics = new string[] {
        "pick_me",
        "pick_me_red",
        "pick_me_blue",
    };

    private GameObject ceilingCheck;

    // Start is called before the first frame update
    void Start()
    {
        ceilingCheck = transform.Find( "CeilingCheck" ).gameObject;
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // setters and getters for health.
    public int GetHealth() {
        return this.health;
    }

    public void SetHealth( int health ) {
        this.health = health;
    }

    // method to damage player.
    public void playerIsDamaged() {
        this.health--;
    }

    public void playerRecoversLife( int toRecover ) {
        this.health += toRecover;

        if ( this.health > healthLimit ) {
            SetHealth( healthLimit );
        }
    }

    /// <summary>
    /// Player is destroyed.
    /// </summary>
    /// <param name="gameController">GameController - GameController class. Used here to call player killed method which checks for reload scene or game over.</param>
    /// <param name="audioSource">AudioSource - AudioSource component to trigger the dying sound.</param>
    public IEnumerator playerIsDestroyed( GameController gameController, AudioSource audioSource ) {
        isDying = true;
        
        // display audio source.
        audioSource.Play();

        // freeze player.
        canMove = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds( 0.5f );

        // fade out player.
        while ( renderer.color.a > 0f ) {
            renderer.color = new Color( renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a - ( fadeSpeed * Time.deltaTime ) );
            yield return null;
        }

        yield return new WaitForSeconds( 3f );

        // call player killed method.
        gameController.PlayerKilled();
    }

}
