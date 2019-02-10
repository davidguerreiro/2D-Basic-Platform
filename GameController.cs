using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{   
    private int coins;
    private int score;
    private int lifes = 3;
    
    void Start()
    {
        PrintData();
    }

    // Update is called once per frame
    void Update()
    {
        PrintData();
    }

    // coins setter and getter.
    public int GetCoins() {
        return this.coins;
    }

    public void SetCoins( int coins ) {
        this.coins = coins;
    }

    // score setter and getter.
    public int GetScore() {
        return this.score;
    }

    public void SetScore( int score ) {
        this.score = score;
    }


    // lives setter and getter.
    public int GetLives() {
        return this.lifes;
    }

    public void SetLives( int lifes ) {
        this.lifes = lifes;
    }

    // add life because 100 coins where collected.
    public void AddLifeFromCoins() {
        AddLife();
        SetCoins( 0 );
    }

    // add a life.
    public void AddLife() {
        this.lifes++;
    }

    // add score.
    public void AddScore() {
        this.score++;
    }

    // add a coin.
    public void AddCoin() {
        this.coins++;
    }

    // prints data on the console.
    private void PrintData() {
        print( "Lives : " + this.lifes + " | Coins  : " + this.coins + " | Score : " + this.score );
    }

    // Game Over.
    public void GameOver() {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}