using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearths : MonoBehaviour
{
    private Player player;
    public int toRecover    = 1;                        // amount of live recovered when the played collects the hearth.
    public float speed      = .5f;                      // bouncing speed.


    // Start is called before the first frame update.
    void Start()
    {
        player  = GameObject.Find( "Player" ).GetComponent<Player>();
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
            player.playerRecoversLife( toRecover );
            Debug.Log( player.GetHealth());
            Destroy( gameObject );
        }
    }

    // bouncing animation for hearts.
    void AnimateHearth() {
       
    }
}
