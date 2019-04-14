using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pressSpaceBarAnimation : MonoBehaviour
{
    public float baseDuration = 1.0f;                   // Base animation duration - Base animation is the standard animation displayed before the user press the space bar button.
    public float transitionDuration = 1.5f;             // Transition animation duration - Transition animation is the animation displayed when the user press the space bar but before the Main Menu is displayed.
    public Coroutine flashSpaceText;                    // Coroutine used to display the text continually.            
    private Text text;                                  // Text componentent.
    private Color colorDisplayed;                       // Color used when the text is displayed.
    private Color colorHidden;                          // Color used when the text is hidden.
    public bool displayBaseAnimation;                  // Whether the base animation is being displayed.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if ( displayBaseAnimation ) {
            flashSpaceText = StartCoroutine( DisplayBaseAnimation() );
        }        
    }

    /// <summary>
    /// Press Start Init class.
    /// </summary>
    public void Init() {
        text = gameObject.GetComponent<Text>();
        colorDisplayed = new Color( text.color.r, text.color.g, text.color.b, 1f );
        colorHidden = new Color( text.color.r, text.color.g, text.color.b, 0f );

        displayBaseAnimation = true;
    }

    /// <summary>
    /// Display press start text base animation.
    /// </summary>
    public IEnumerator DisplayBaseAnimation() {
        displayBaseAnimation = false;

        if ( text.color.a == 1f ) {
            text.color = colorHidden;
            yield return new WaitForSeconds( baseDuration );
        } else {
            text.color = colorDisplayed;
            yield return new WaitForSeconds( baseDuration );
        }

        displayBaseAnimation = true;
    }
}
