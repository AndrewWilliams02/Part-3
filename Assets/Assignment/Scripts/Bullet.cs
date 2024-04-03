using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    protected static float bulletSpeed; //Variable for bullets movement speed
    Vector2 direction; //Variable for the direction the bullet moves in after spawned

    //Public function to set bullet direction
    public void BulletDirection(Vector2 mouseDirection)
    {
        direction = mouseDirection;
    }

    //Protected function to set bullet speed
    protected virtual void SetBulletSpeed()
    {
        bulletSpeed = 5f;
    }

    //Protected function to move bullet
    protected virtual void MoveObject()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }

    //Protected function to handle bullet & enemy collisions and destroys both
    protected virtual void EnemyHit(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        SetBulletSpeed();
        MoveObject();

        //Conditional statement that destroys all bullets if player dies
        if (PlayerMovement.playerDied)
        {
            Destroy(gameObject);
        }
    }

    //Function that destroys bullet when it is off-screen
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    //Function that destroys bullet and enemy when they collide
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHit(collision);
        TrackScore.UpdateScore(); //Runs score function to add 1 when enemy is collided with
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
