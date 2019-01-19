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

    void blockIsHit() {
        // TODO - Display animation.
        // TODO - Show children gameobjects.
        hardness--;

        if ( hardness <= 0 ) {
            Destroy( gameObject );
        }
    }
}
