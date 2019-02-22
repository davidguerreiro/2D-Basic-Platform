using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{   
    void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.tag == "Player" ) {
            if ( SceneManager.GetActiveScene().name == "Level1" ) {
                Destroy( gameObject );
                SceneManager.LoadScene("Level2");
            }
        }
    }
}
