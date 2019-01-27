using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsDamaged : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject enemyParent;
    void Start()
    {
        enemyParent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // collision controller for waek point in enemies.
    void OnCollisionEnter2D(Collision2D other)
    {   
        // if player hits this collider, the enemy is damaged by the player.
        if ( other.gameObject.tag == "Player" ) {
            enemyParent.GetComponent<BasicEnemy1Behaviour>().EnemyIsDamaged();
        }
    }
}
