using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BulletSpawn : MonoBehaviour
{
    public GameObject[] bullets = new GameObject[3];
    GameObject currentBullet;
    Vector2 bulletSpawn;
    Vector2 mouseDirection;
    float bulletTimer = 0f;
    protected float bulletCooldown = 1f;
    void Start()
    {
        currentBullet = bullets[0];
    }
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        if (bulletTimer <= 0)
        {
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
            bulletCooldown = 3f;
        }
    }
}
