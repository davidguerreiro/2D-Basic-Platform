using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterWaves : MonoBehaviour
{
    public float speed = 10f;                   // Animation speed.
    public float amplitude = 5f;                // Wave movement amplitude.
    public bool inverse = false;                // If true, it will go from down to up instead.
    private bool triggerAnimation = false;       // Flag to control the animation coroutine and improve performance.
    private float maxHeight;                     // Max wave height value for Y axis.
    private float minHeight;                     // Min wave heigh value for Y axis.

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if ( triggerAnimation ) {
            StartCoroutine( moveUpAndDown() );
        }
    }

    /// <summary>
    /// Calculates max and min values for the animations and
    /// initialises the coroutines.
    /// </summary>
    private void Init() {
        float radio = amplitude / 2;
        minHeight = transform.localPosition.y - radio;
        maxHeight = transform.localPosition.y + radio;

        triggerAnimation = true;
    }

    /// <summary>
    /// Moves the wave up and down.
    /// </summary>
    private IEnumerator moveUpAndDown() {
        triggerAnimation = false;

        if ( ! inverse ) {
            if ( transform.localPosition.y < maxHeight ) {
                while (  transform.localPosition.y < maxHeight ) {
                    transform.localPosition = new Vector2( transform.localPosition.x, transform.localPosition.y + ( speed * Time.deltaTime ) );
                    yield return null;
                }
            } else {
                while ( transform.localPosition.y > minHeight ) {
                    transform.localPosition = new Vector2( transform.localPosition.x, transform.localPosition.y - ( speed * Time.deltaTime ) );
                    yield return null;
                }
            }
        } else {
           if ( transform.localPosition.y > minHeight ) {
                while (  transform.localPosition.y > minHeight ) {
                    transform.localPosition = new Vector2( transform.localPosition.x, transform.localPosition.y - ( speed * Time.deltaTime ) );
                    yield return null;
                }
            } else {
                while ( transform.localPosition.y < maxHeight ) {
                    transform.localPosition = new Vector2( transform.localPosition.x, transform.localPosition.y + ( speed * Time.deltaTime ) );
                    yield return null;
                }
            } 
        }

        triggerAnimation = true;
    }
}
