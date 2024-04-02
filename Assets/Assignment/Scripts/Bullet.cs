using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{
    protected static float bulletSpeed;
    Vector2 direction;
    public void BulletDirection(Vector2 mouseDirection)
    {
        direction = mouseDirection;
    }
    protected virtual void SetBulletSpeed()
    {
        bulletSpeed = 5f;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        SetBulletSpeed();
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }
}
