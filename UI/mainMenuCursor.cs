using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuCursor : MonoBehaviour
{
    public float speed = 10f;               // Animation speed.
    public float amplitude = 6f;           // Animation amplitude on the X axis.
    public bool onRoutine = false;         // Wheter the animation coroutine is running or not.
    private float initialX;                 // Initial X cursor value.
    private float toMove;                   // X value to move the cursor on the animation.

    // Start is called before the first frame update
    void Start()
    {
        // Init();
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Init();    
    }

    // Update is called once per frame
    void Update()
    {
        if ( onRoutine == false ) {
            StartCoroutine( AnimateCursor() );
        }
    }

    /// <summary>
    /// Init cursor class.
    /// </summary>
    public void Init() {
        initialX = transform.localPosition.x;
        toMove = initialX - amplitude;

        onRoutine = false;
    }

    /// <summary>
    /// Animates cursor.
    /// </summary>
    private IEnumerator AnimateCursor() {
        onRoutine = true;

        if ( transform.localPosition.x > toMove ) {
            while ( transform.localPosition.x > toMove ) {
                transform.localPosition = new Vector3( transform.localPosition.x - ( speed * Time.deltaTime ), transform.localPosition.y, transform.localPosition.z );
                yield return null;
            }
        }

        if ( transform.localPosition.x <= toMove ) {
            while ( transform.localPosition.x < initialX ) {
                transform.localPosition =  new Vector3( transform.localPosition.x + ( speed * Time.deltaTime ), transform.localPosition.y, transform.localPosition.z );
                yield return null;
            }
        }

        onRoutine = false;
    } 
}
