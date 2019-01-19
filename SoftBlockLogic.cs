using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBlockLogic : MonoBehaviour
{

    public int hardness = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // block logic when it is hit by the player.
    public void blockIsHit() {
        // TODO - Display animation.
        hardness--;

        // if the block if not destroyed, show fissures.
        if ( hardness <= 0 ) {
            Destroy( gameObject );
        } else {
            showFissures();
        }
    }

    // display all fissures in the block after it is hit but not destroyed.
    private void showFissures() {
        for ( int i = 0; i < transform.childCount; i++ ) {
            transform.GetChild( i ).gameObject.SetActive( true );
        }
    }
}
