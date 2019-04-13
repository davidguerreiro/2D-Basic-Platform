using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class removeHud : MonoBehaviour
{
    private GameController gameController;
    private string[] nonPlayableScenes;
    private GameObject levelUI;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    /// <summary>
    /// Hide UI in non Playable scenes.
    /// </summary>
    private void HideMainUI() {
        nonPlayableScenes = gameController.GetNonPlayableScenes();

        if ( Array.IndexOf( nonPlayableScenes, SceneManager.GetActiveScene().name  ) > -1 ) {
            GameObject.Find( "GamePlayerData" ).SetActive( false );
        }
    }

    /// <summary>
    /// Display level's UI.
    /// </summary>
    private void DisplayMainUI() {
        if ( levelUI != null ) {
            levelUI.SetActive( true );
        }
    }

    /// <summary>
    /// Initialise remove UI.
    /// </summary>
    private void Init() {
        gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
        levelUI = GameObject.Find( "GamePlayerData" );

        if ( gameController != null ) {
            HideMainUI();
        } else {
            DisplayMainUI();
        }
    }
}
