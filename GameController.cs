using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    private int coins;
    private int score;
    private int lifes;
    
    void Start()
    {
        // Data saved in PlayerPrefs.
        SetCoins( PlayerPrefs.GetInt( "coins" ) );
        SetScore( PlayerPrefs.GetInt( "score" ) );
        SetLives( PlayerPrefs.GetInt( "lifes" ) );
        // PrintData();
    }

    // Update is called once per frame
    void Update()
    {
        // PrintData();
    }

    // coins setter and getter.
    public int GetCoins() {
        return this.coins;
    }

    public void SetCoins( int coins ) {
        this.coins = coins;
        PlayerPrefs.SetInt( "coins", this.coins );
    }

    // score setter and getter.
    public int GetScore() {
        return this.score;
    }

    public void SetScore( int score ) {
        this.score = score;
        PlayerPrefs.SetInt( "score", this.score );
    }


    // lives setter and getter.
    public int GetLives() {
        return this.lifes;
    }

    public void SetLives( int lifes ) {
        this.lifes = lifes;
        PlayerPrefs.SetInt( "lifes", this.lifes );
    }

    // add life because 100 coins where collected.
    public void AddLifeFromCoins() {
        AddLife();
        SetCoins( 0 );
    }

    // add a life.
    public void AddLife() {
        SetLives( ++this.lifes );
    }

    // remove life.
    public void RemoveLife() {
        SetLives( --this.lifes );
    }

    // add score.
    public void AddScore() {
        SetScore( ++this.score );
    }

    // add a coin.
    public void AddCoin() {
        SetCoins( ++this.coins );
    }

    // prints data on the console.
    private void PrintData() {
        print( "Lives : " + this.lifes + " | Coins  : " + this.coins + " | Score : " + this.score );
    }

    // Game Over.
    public void GameOver() {
        SceneManager.LoadScene( "GameOver" );
    }

    /// <summary>
    /// Method called when the player is killed.
    /// </summary>
    public void PlayerKilled() {
        RemoveLife();
        SetCoins( 0 );

        if ( this.lifes > 0 ) {
            ReloadCurrentScene();
        } else {
            GameOver();
        }
    }

    /// <summary>
    /// Reloads current scene.
    /// </summary>
    public void ReloadCurrentScene() {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}