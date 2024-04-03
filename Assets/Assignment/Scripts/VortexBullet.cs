using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexBullet : Bullet
{
    private float elapsedTime = 0f; //Variable that tracks time for Lerp
    private float duration = 5f; //Variable that decides length of Lerp
    private float destroyTimer = 0f; //Variable that tracks time since bullet stopped
    private bool freezeBullet = false; //Variable to track if bullet is frozen
    private bool coroutineStarted = false; //Variable to track if the coroutine started

    private Vector3 initialSize; //Variable to get the initial size of bullet
    private Vector3 targetSize; //Variable to set the target size of bullet

    //Function to intialize Lerp variable as well as start bullet grow coroutine
    private void Start()
    {
        initialSize = transform.localScale;
        targetSize = new Vector3(3, 3, 3);
        StartCoroutine(GrowBullet());
    }

    //Overridden function to set bullet speed
    protected override void SetBulletSpeed()
    {
        bulletSpeed = 0.75f;
    }

    //Coroutine function to grow bullet to a scale of 3 over the span of 5 seconds after being spawned in
    IEnumerator GrowBullet()
    {
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(initialSize, targetSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetSize; //Ensures target size is reached
        freezeBullet = true; //Freezes bullet when size reached
    }

    //Coroutine function to shrink bullet to disappear over the span of 0.2 seconds after being frozen
    IEnumerator ShrinkBullet()
    {
        initialSize = transform.localScale;
        targetSize = new Vector3(0, 0, 0);
        elapsedTime = 0f;
        duration = 0.2f;
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(initialSize, targetSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetSize; //Ensures target size is reached
    }

    //Overridden function to start destroy process of bullet if it has been frozen and the shrink coroutine has not yet started
    protected override void MoveObject()
    {
        if (!coroutineStarted) {
            if (freezeBullet)
            {
                //If bullet has been frozen in place for 2 seconds start shrink & destroy coroutine
                destroyTimer += Time.deltaTime;
                if (destroyTimer >= 2f)
                {
                    StartCoroutine(ShrinkBullet());
                    coroutineStarted = true;
                }
            }
            else
            {
                base.MoveObject();
            }
        }
    }

    //Overriden function to destroy ONLY enemies when colliding with this bullet
    protected override void EnemyHit(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
