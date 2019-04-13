using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeepUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        checkDuplicatedMainUIObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        KeepGameObject();
    }

    /// <summary>
    /// Prevents Unity for destroying current gameObject after a
    /// scene has been loaded or current scene is re-loaded.
    /// </summary>
    private void KeepGameObject() {
        // DontDestroyOnLoad( transform.gameObject );
    }

    /// <summary>
    /// Check if other Canvas elements have been duplicated.
    /// This is required because the original canvas element for 
    /// main user UI is not destroyed when scenes are lodaded / re-loaded.
    /// </summary>
    private void checkDuplicatedMainUIObjects() {
        int otherCanvasElements = GameObject.FindGameObjectsWithTag( "player_ui" ).Length;

        if ( FindObjectsOfType( GetType() ).Length > 1 ) {
            Destroy( gameObject );
        }
    }
}
