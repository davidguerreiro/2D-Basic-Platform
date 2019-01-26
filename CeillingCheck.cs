using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeillingCheck : MonoBehaviour
{
    void OnCollisionEnter2D( Collision2D coll )
    {
        GameObject objectColl = coll.gameObject;

        // damage softblocks when they are hit by the character with the head.
        if ( objectColl.tag == "soft_block" ) {
            objectColl.GetComponent<SoftBlockLogic>().blockIsHit();
        }
    }
}
