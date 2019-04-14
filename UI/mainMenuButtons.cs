using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class mainMenuButtons : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public GameObject cursor;                  // Cursor GameObject.
    private Button button;                      // Current button component.
    private AudioSource audioSource;           // AudioSource component.
    private mainMenuCursor cursorClass;         // Cursor class.

    // Start is called before the first frame update
    void Start()
    {
        Init();   
    }

    /// <summary>
    /// Initilise button.
    /// </summary>
    private void Init() {
        button = gameObject.GetComponent<Button>();
        audioSource = gameObject.GetComponent<AudioSource>();
        cursorClass = cursor.GetComponent<mainMenuCursor>();
    }

    /// <summary>
    /// Enable cursor when the button is active
    /// </summary>
    /// <param name="eventData">BaseEventData</param>
    public void OnSelect( BaseEventData eventData ) {
        cursor.SetActive( true );
        cursorClass.onRoutine = false;
    }

    /// <summary>
    /// Disable cursor when the button is not longer active.
    /// </summary>
    /// <param name="eventData">BaseEventData</param>
    public void OnDeselect( BaseEventData eventData ) {
        cursor.SetActive( false );
        audioSource.Play();
    }
}
