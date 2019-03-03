using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBlockLogic : MonoBehaviour
{

    public int hardness = 2;

    // block logic when it is hit by the player.
    public void blockIsHit() {
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
