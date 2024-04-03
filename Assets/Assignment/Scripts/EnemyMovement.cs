using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 target; //Variable that sets enemies target location
    public static GameObject player; //Variable that tracks player location
    public static float enemySpeed = 2f; //Variable that tracks player speed

    void Update()
    {
        //If player is alive moves the enemy in the direction of the player until they collide
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * enemySpeed * Time.deltaTime);
        }

        //If player dies despawn all enemies
        if (PlayerMovement.playerDied)
        {
            Destroy(gameObject);
        }
    }
}
