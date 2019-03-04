using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class companySceneController : MonoBehaviour
{

    public GameObject companyText;
    public float timeDuration = 1f;
    public float delayInit = 1f;

    private Text TextComponent;

    // Start is called before the first frame update
    void Start()
    {   
        TextComponent = companyText.GetComponent<Text>();

        // fade in title.
        StartCoroutine( FadeTextToFullAlpha( timeDuration, TextComponent , delayInit ) );

        // fade out title.
        StartCoroutine( FadeTextToZeroAlpha( timeDuration, TextComponent, delayInit + 3f ) );

        // load game title scene.
        StartCoroutine( LoadTitleScene( 7f ) );

    }

    /// <summary>
    /// Fade In Text component
    /// </summary>
    /// <param name="time">Float time animation duration</param>
    /// <param name="text">GameObject Text component</param>
    /// <param name="delay">Float time before the fade starts</param>
    public IEnumerator FadeTextToFullAlpha( float time, Text text, float delay = 0 ) {

        // delay fade if required.
        yield return new WaitForSeconds( delay );

        text.color = new Color( text.color.r, text.color.g, text.color.b, 0 );
        while ( text.color.a < 1.0f ) {
            text.color = new Color( text.color.r, text.color.g, text.color.b, text.color.a + ( Time.deltaTime / time ) );
            yield return null;
        }
    }

    /// <summary>
    /// Fade Out Text component
    /// </summary>
    /// <param name="time">Float time animation duration</param>
    /// <param name="text">GameObject Text component</param>
    /// <param name="delay">Float time before the fade starts</param>
    public IEnumerator FadeTextToZeroAlpha( float time, Text text, float delay = 0 ) {

        // delay fade if required.
        yield return new WaitForSeconds( delay );

        text.color = new Color( text.color.r, text.color.g, text.color.b, 1 );
        while( text.color.a > 0.0f ) {
            text.color = new Color( text.color.r, text.color.g, text.color.b, text.color.a - ( Time.deltaTime / time ) );
            yield return null;
        }
    }

    /// <summary>
    /// Loads the next scene 
    /// </summary>
    /// <param name="delay">Float - Time to delay changing scenes</param>
    public IEnumerator LoadTitleScene( float delay = 0 ) {
        yield return new WaitForSeconds( delay );
        SceneManager.LoadScene( "MainTitle" );
    }
}
