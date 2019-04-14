using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlButtons : MonoBehaviour
{
    private float transitionSpeed = 5f;         // Speed transition animation.
    private GameObject SceneCover;               // Cover used for transition between scenes.
    private Image coverImage;                   // Image component from scene cover.
    private AudioSource audioSource;            // AudioSource component.
    private bool isSelectable = true;           // Wheter the button has already been enabled by the user or not.


    /// <summary>
    /// Load a new scene. Use this method to load new levels.
    /// </summary>
    /// <param name="levelName">String - Name of the scene to be loaded</param>
    public void startLevel( string levelName ) {
        if ( levelName != "" && isSelectable ) {
            StartCoroutine( loadNextScene( levelName ) );
        } else {
            Debug.Log( "Scene cannot be loaded - Invalid Scene name or button not longer selectable" );
        }
    }

    /// <summary>
    /// Trigger transition scene animation once the
    /// user has selected this button.
    /// </summary>
    /// <param name="levelName">String - Name of the scene to be loaded</param>
    private IEnumerator loadNextScene( string levelName ) {
        isSelectable = false;

        SceneCover = GameObject.Find( "SceneCover" );
        coverImage = SceneCover.GetComponent<Image>();
        audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.Play();

        while ( coverImage.color.a < 1f ) {
            coverImage.color = new Color( coverImage.color.r, coverImage.color.g, coverImage.color.b, coverImage.color.a + ( transitionSpeed * Time.deltaTime ) );
            yield return null;
        }

        yield return new WaitForSeconds( 1.5f );
        SceneManager.LoadScene( levelName );
    }
}
