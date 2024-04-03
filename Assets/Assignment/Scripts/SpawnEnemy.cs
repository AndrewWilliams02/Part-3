using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy; //Varible to spawn enemy prefab
    public GameObject player; //Variable to track player location
    Vector2 randomSpawn; //Variable to spawn enemy at random location
    public float enemySpawnTimer = 0f; //Variable to track time between enemy spawns
    float timerGoal = 3f; //Variable to set timer for when next enemy will spawn
    void Start()
    {
        EnemyMovement.player = player; //Set player variable in player movement script to track players location
    }

    void Update()
    {
        //If player is alive continue timer
        if (!PlayerMovement.playerDied)
        {
            enemySpawnTimer += Time.deltaTime;
        }

        //If enemy spawn timer reaches the goal then spawn enemy at a random location and reset timer
        if(enemySpawnTimer >= timerGoal)
        {
            randomSpawn.x = Random.Range(-7.51f, 7.51f);
            randomSpawn.y = Random.Range(-4.51f, 4.51f);
            Instantiate(enemy, randomSpawn, Quaternion.identity);

            //If time goal is above 1.2 seconds increase the speed of enemies and reduce spawn time between enemies
            if(timerGoal >= 1.2)
            {
                timerGoal -= 0.2f;
                EnemyMovement.enemySpeed += 0.1f;
            }
            enemySpawnTimer = 0f;
        }
    }
}