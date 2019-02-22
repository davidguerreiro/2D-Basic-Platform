using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearths : MonoBehaviour
{
    public int toRecover    = 1;                        // amount of live recovered when the played collects the hearth.
    // public AnimationCurve myCurve;                      // Animation Curve item.
    private Player player;                              // Player gameobject.

    public float speed = 3f;                            // bouncing animation speed.
    public float height = 0.1f;                         // bouncing animation amplitude.



    // Start is called before the first frame update.
    void Start()
    {
        player  = GameObject.Find( "Player" ).GetComponent<Player>();
    }

    // Update is called once per frame.
    void Update()
    {
        // AnimateHearth();
    }

    // collision controller for hearts.
    void OnCollisionEnter2D(Collision2D other)
    {
        if ( other.gameObject.tag == "Player" ) {
            player.playerRecoversLife( toRecover );
            Destroy( gameObject );
        }
    }

    // bouncing animation for hearts.
    void AnimateHearth() {
       float newY = Mathf.Sin( Time.time * speed );
       transform.position = new Vector3( transform.position.x, transform.position.y + ( newY * height ), transform.position.z );
    }
}
