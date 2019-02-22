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
        AnimateHearth();
        Debug.Log( transform.position.x );
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
        //Debug.Log( myCurve.Evaluate( Time.time % myCurve.length ) );
       //transform.position = new Vector3( transform.position.x, myCurve.Evaluate( Time.time % myCurve.length ), transform.position.z );
       Vector3 pos = transform.position;
       float newY = Mathf.Sin( Time.time * speed );
       transform.position = new Vector3( pos.x, ( newY * height ), pos.z );
    }
}
