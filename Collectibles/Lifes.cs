using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    public float speed = 3f;                            // bouncing animation speed.
    public float height = 0.1f;                         // bouncing animation amplitude.

    // Update is called once per frame
    void Update()
    {
        // AnimateLifeCollectible();
    }

    // bouncing animations for lifes.
    void AnimateLifeCollectible() {
        float newY = Mathf.Sin( Time.time * speed );
        transform.position = new Vector3( transform.position.x, ( newY * height ), transform.position.z );
    }
}
