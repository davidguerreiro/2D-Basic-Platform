using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainGameUIController : MonoBehaviour
{
    private GameController gameController;
    private Text coinsText;
    private Text lifesText;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
        coinsText = GameObject.Find( "LivesText" ).GetComponent<Text>();
        lifesText = GameObject.Find( "ScoreText" ).GetComponent<Text>();

        if ( gameController != null && coinsText != null && lifesText != null ) {
            UpdateMainUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( gameController != null && coinsText != null && lifesText != null ) {
            UpdateMainUI();
        }
    }

    /// <summary>
    /// Updates Main Game UI text
    /// </summary>
    private void UpdateMainUI() {
        coinsText.text = "Coins: " + gameController.GetCoins();
        lifesText.text = "Lifes: " + gameController.GetLives();
    }
}
