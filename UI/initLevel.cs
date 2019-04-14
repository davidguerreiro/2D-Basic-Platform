using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initLevel : MonoBehaviour
{
    public GameObject SceneCover;               // Scene cover for transition animation.
    public GameObject StartLevelSide;           // Level side image.
    public GameObject LevelData;                // Level Data gameobject which contains level name text, separator bar raw image and level zone text.
    private Image coverImage;                   // Scene cover image Image component.
    private float moveSideBarSpeed = 400f;       // Sidebar movement animation speed.
    private float moveLevelDataSpeed = 1200f;     // Text movement animation speed.
    private float fadeOutSpeed = 8f;            // Scene cover fade out animatio speed. 
    private float toMoveSideBar = - 444.7f;     // Where to move the sidebar
    private float barInitialPosition;           // Sidebar initial position.
    private float toMoveLevelData = - 25f;        // Where to move level data gameObject.
    private float levelDataInitialPosition;     // Level Data initial position.
    private bool initFadeOut = false;            // Wheter to fade out the scene cover.
    private bool initRemoveItems = false;        // Wheter to remove init level UI items from screen.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        triggerCoroutines();
    }

    /// <summary>
    /// Initialise init level animations.
    /// </summary>
    private void Init() {
        coverImage = SceneCover.GetComponent<Image>();
        barInitialPosition = StartLevelSide.transform.localPosition.x;
        levelDataInitialPosition = LevelData.transform.localPosition.x;

        // init get elements inside coroutines.
        StartCoroutine( moveSidebarIn() );
        StartCoroutine( moveLevelDataIn() );
    }

    /// <summary>
    /// Check wheter the next coroutines have to be called.
    /// This method is called in Update every frame.
    /// </summary>
    private void triggerCoroutines() {
        
        // trigger fade out scene cover.
        if ( initFadeOut ) {
            StartCoroutine( fadeSceneCoverOut() );
        }

        // trigger clear init level UI.
        if ( initRemoveItems ) {
            StartCoroutine( removeSideBar() );
            StartCoroutine( removeLevelData() );
        }
    }

    /// <summary>
    /// Moves sidebar inside the game screen.
    /// </summary>
    private IEnumerator moveSidebarIn() {
        yield return new WaitForSeconds( 1f );
        while ( StartLevelSide.transform.localPosition.x < toMoveSideBar ) {
            StartLevelSide.transform.localPosition = new Vector3( StartLevelSide.transform.localPosition.x + ( moveSideBarSpeed * Time.deltaTime ), StartLevelSide.transform.localPosition.y, StartLevelSide.transform.localPosition.z );
            yield return null;
        }
    }

    /// <summary>
    /// Moves level data text inside the game screen.
    /// </summary>
    private IEnumerator moveLevelDataIn() {
        yield return new WaitForSeconds( 1f );
        while ( LevelData.transform.localPosition.x > toMoveLevelData ) {
            LevelData.transform.localPosition = new Vector3( LevelData.transform.localPosition.x - ( moveLevelDataSpeed * Time.deltaTime ), LevelData.transform.localPosition.y, LevelData.transform.localPosition.z );
            yield return null;
        }

        yield return new WaitForSeconds( 2f );
        initFadeOut = true;
    }

    /// <summary>
    /// Fade out scene cover image.
    /// </summary>
    private IEnumerator fadeSceneCoverOut() {
        initFadeOut = false;

        while ( coverImage.color.a > 0f ) {
            coverImage.color = new Color( coverImage.color.r, coverImage.color.g, coverImage.color.b, coverImage.color.a - ( fadeOutSpeed * Time.deltaTime ) );
            yield return null;
        }

        SceneCover.SetActive( false );
        yield return new WaitForSeconds( 0.5f );
        initRemoveItems = true;
    }

    /// <summary>
    /// Remove Sidebar from the scene and disable it.
    /// </summary>
    private IEnumerator removeSideBar() {
        while ( StartLevelSide.transform.localPosition.x > barInitialPosition ) {
            StartLevelSide.transform.localPosition = new Vector3( StartLevelSide.transform.localPosition.x - ( moveSideBarSpeed * Time.deltaTime ), StartLevelSide.transform.localPosition.y, StartLevelSide.transform.localPosition.z );
            yield return null;
        }

        StartLevelSide.SetActive( false );
    }

    /// <summary>
    /// Remove level data gameobject from the scene
    /// and disable it. Then allow player to start moving
    /// the main character.
    /// </summary>
    private IEnumerator removeLevelData() {
        initRemoveItems = false;

        while ( LevelData.transform.localPosition.x < levelDataInitialPosition ) {
            LevelData.transform.localPosition = new Vector3( LevelData.transform.localPosition.x + ( moveLevelDataSpeed * Time.deltaTime ), LevelData.transform.localPosition.y, LevelData.transform.localPosition.z );
            yield return null;
        }

        LevelData.SetActive( false );

        // TODO: Set player.canMove to true.
    }
}
