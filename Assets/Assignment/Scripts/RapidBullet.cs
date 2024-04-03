using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidBullet : Bullet
{
    private float elapsedTime = 0f; //Variable that tracks time for Lerp
    private float duration = 0.5f; //Variable that decides length of Lerp

    private Vector3 initialSize; //Variable to get the initial size of bullet
    private Vector3 targetSize; //Variable to set the target size of bullet

    //Function to intialize Lerp variable as well as start bullet shrink coroutine
    private void Start()
    {
        initialSize = transform.localScale;
        targetSize = new Vector3(0, 0, 0);
        StartCoroutine(ShrinkBullet());
    }

    //Overridden function to set bullet speed
    protected override void SetBulletSpeed()
    {
        bulletSpeed = 10f;
    }

    //Coroutine function to shrink bullet to disappear over the span of 0.5 seconds after being spawned in
    IEnumerator ShrinkBullet()
    {
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(initialSize, targetSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetSize; //Ensures target size is reached
    }
}