using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Load a new scene. Use this method to load new levels.
    /// </summary?
    /// <param name="levelName">String - Name of the scene to be loaded</param>
    public void startLevel( string levelName ) {
        Debug.Log( "This is called" );
        Debug.Log( levelName );
        if ( levelName != "" ) {
            SceneManager.LoadScene( levelName );
        } else {
            Debug.Log( "Scene cannot be loaded - Invalid Scene name" );
        }
    }
}
