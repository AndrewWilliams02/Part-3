using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletSpawn : MonoBehaviour
{
    public GameObject[] bullets = new GameObject[3]; //Variable for different bullet types
    GameObject currentBullet; //Variable for current bullet type being used
    Vector2 bulletSpawn; //Variable for the bullets spawn location
    Vector2 mouseDirection; //Variable for the direction of the mouse from player for bullet to follow
    float bulletTimer = 0f; //Variable to track the time for bullet cooldowns
    protected float bulletCooldown = 1f; //Variable for the total cooldown for bullets

    void Start()
    {
        currentBullet = bullets[0]; //Sets the bullet being spawned to default
    }

    void Update()
    {
        bulletTimer -= Time.deltaTime; //Counts down for bullet cooldown
        if (bulletTimer <= 0)
        {
            //If bullet cooldown is over & mouse is clicked spawns another bullet moving toward the mouse from the player
            if (Input.GetMouseButtonDown(0))
            {
                bulletSpawn = this.transform.position;
                mouseDirection = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
                GameObject newBullet = Instantiate(currentBullet, bulletSpawn, Quaternion.identity);
                newBullet.GetComponent<Bullet>().BulletDirection(mouseDirection);
                bulletTimer = bulletCooldown;
            }
        }
    }

    //Function that changes current bullet depending on dropdown selection index
    public void SetBullet(int index)
    {
        currentBullet = bullets[index];
        if(index == 0)
        {
            bulletCooldown = 1f;
        } else if (index == 1)
        {
            bulletCooldown = 0.1f;
        }
        else if (index == 2)
        {
            bulletCooldown = 5f;
        }
    }
}
