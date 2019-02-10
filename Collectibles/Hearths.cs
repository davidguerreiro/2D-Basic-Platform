using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearths : MonoBehaviour
{
    private GameController gameController;
    public float speed = .5f;                   // bouncing speed.
    public float amplitude = .5f;               // bouncing amplitude.
    private float tempVal;
    private Vector3 tempPos;                      
    
    // Start is called before the first frame update.
    void Start()
    {
        gameController = GameObject.Find( "GameController" ).GetComponent<GameController>();
        tempVal = transform.position.y;
    }

    // Update is called once per frame.
    void Update()
    {
        AnimateHearth();
    }

    // collision controller for hearts.
    void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.tag == "Player" ) {
            gameController.AddLife();
            Debug.Log( gameController.GetLives());
            Destroy( gameObject );
        }
    }

    // bouncing animation for hearts.
    void AnimateHearth() {
        tempPos.y = tempVal + amplitude + Mathf.Sin( speed * Time.deltaTime );
        transform.position = tempPos;
    }
}
