using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainGameUIController : MonoBehaviour
{
    private GameController gameController;              // GameController gameObject - controls game / level flow.
    private Text coinsText;                             // Coins text UI gameobject.
    private Text lifesText;                             // Lifes text UI gameobject.
    private GameObject levelUI;                         // Level UI panel gameObject.

    // Start is called before the first frame update
    void Start()
    {
        Init();
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
        coinsText.text = ": " + gameController.GetCoins();
        lifesText.text = ": " + gameController.GetLives();
    }

    /// <summary>
    /// Init level UI.
    /// </summary>
    private void Init() {
        // init UI.
        levelUI = GameObject.Find( "GamePlayerData" );

        if ( levelUI != null ) {
            levelUI.SetActive( true );
        }

        // update UI during gamePlay.
        gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
        coinsText = GameObject.Find( "CoinsText" ).GetComponent<Text>();
        lifesText = GameObject.Find( "LifesText" ).GetComponent<Text>();

        if ( gameController != null && coinsText != null && lifesText != null ) {
            UpdateMainUI();
        }
    }
}
