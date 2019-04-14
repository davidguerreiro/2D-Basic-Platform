using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleScreenController : MonoBehaviour
{
    public GameObject backgroundImage;                  // Main title background image gameObject.
    public GameObject gameTitle;                        // Main title text gameObject.
    public GameObject developerText;                    // Developer text.
    public GameObject mainMenuPanel;                    // Main menu panel gameObject.
    public GameObject pressStartText;                   // Press start text gameObject.
    public GameObject sceneCover;                       // Black image used to transition from main title scene to other scenes.
    private float toMoveTitle = - 479f;                 // Where to move the title in the X axis during the animation.
    private float fadeBackSpeed = 1f;                  // Background fade in animation.
    private float fadeTextSpeed = 1.5f;                  // Screen text fade in speed;
    private float moveText = 200f;                       // Move title animation speed;
    private bool animateBackGround = false;             // Wheter to start the background animation;
    private bool animateTitle = false;                  // Wheter to start the title animation.
    private bool displayOtherTexts = false;             // Wheter to display the press space bar text and the developer text.
    private bool mainAnimationsCompleted = false;       // Wheter all the animations for main title screen have been completed.
    private RawImage backgroundImageComp;               // Background image component.
    private Text gameTitleText;                         // Game Title Text component.
    private Text devText;                               // Developer Text component.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        InitCoroutines();
    }

    /// <summary>
    /// Init title screen controller.
    /// </summary>
    private void Init() {
        // get components from UI gameobjects.
        backgroundImageComp = backgroundImage.GetComponent<RawImage>();
        gameTitleText = gameTitle.GetComponent<Text>();
        devText = developerText.GetComponent<Text>();

        // trigger first animation - the background image.
        animateBackGround = true;
    }

    /// <summary>
    /// Display animations and init coroutines
    /// This method is only called in Update.
    /// </summary>
    private void InitCoroutines() {
        if ( animateBackGround ) {
            StartCoroutine( displayBackgroundImage() );
        }

        if ( animateTitle ) {
            StartCoroutine( displayTitle() );
        }

        if ( displayOtherTexts ) {
            StartCoroutine( displayAllOtherElements() );
        }
    }

    /// <summary>
    /// Fade in background image.
    /// </summary>
    private IEnumerator displayBackgroundImage() {
        bool internalFlag = true;                   // Used to avoid triggeing the title animation several times during the fade in.
        animateBackGround = false;
        yield return new WaitForSeconds( 2f );

        while ( backgroundImageComp.color.a < 1f ) {
            backgroundImageComp.color = new Color( backgroundImageComp.color.r, backgroundImageComp.color.g, backgroundImageComp.color.b, backgroundImageComp.color.a + ( fadeBackSpeed * Time.deltaTime ) );

            yield return new WaitForSeconds( 0.1f );

            // show title before the animation is totally completed.
            if ( backgroundImageComp.color.a > 0.6f && internalFlag == true ) {
                animateTitle = true;
                internalFlag = false;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Main title screen title animation.
    /// </summary>
    private IEnumerator displayTitle() {
        animateTitle = false;

        // fade in text.
        while( gameTitleText.color.a < 1f ) {
            gameTitleText.color = new Color( gameTitleText.color.r, gameTitleText.color.g, gameTitleText.color.b, gameTitleText.color.a + ( fadeTextSpeed * Time.deltaTime ) );
            yield return null;
        }

        yield return new WaitForSeconds( 1f );

        // move title to the right.
        while ( gameTitle.transform.localPosition.x > toMoveTitle ) {
            gameTitle.transform.localPosition = new Vector3( gameTitle.transform.localPosition.x - ( moveText * Time.deltaTime ), gameTitle.transform.localPosition.y, gameTitle.transform.localPosition.z );
            yield return null;
        }

        displayOtherTexts = true;
    }

    /// <summary>
    /// Display press spacebar text and developer name
    /// text.
    /// </summary>
    private IEnumerator displayAllOtherElements() {
        displayOtherTexts = false;

        // display press space bar text.
        pressStartText.SetActive( true );

        // fade in dev text.
        while ( devText.color.a < 1f ) {
            devText.color = new Color( devText.color.r, devText.color.g, devText.color.b, devText.color.a + ( fadeTextSpeed * Time.deltaTime ) );
            yield return null;
        }
    }
}
