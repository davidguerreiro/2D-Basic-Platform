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
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
        Debug.Log( gameController );

        if ( gameController != null ) {
            HideMainUI();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Hide UI in non Playable scenes.
    /// </summary>
    private void HideMainUI() {
        nonPlayableScenes = gameController.GetNonPlayableScenes();

        if ( Array.IndexOf( nonPlayableScenes, SceneManager.GetActiveScene().name  ) > -1 ) {
            Debug.Log( GameObject.Find( "CoinsText" ).GetComponent<Text>().text );
            GameObject.Find( "CoinsText" ).GetComponent<Text>().text = " ";
            GameObject.Find( "LifesText" ).GetComponent<Text>().text = " ";
            Debug.Log( GameObject.Find( "CoinsText" ).GetComponent<Text>().text );
        }
    }
}
