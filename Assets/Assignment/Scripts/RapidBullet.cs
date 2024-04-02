using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidBullet : Bullet
{
    private float elapsedTime = 0f;
    private float duration = 0.75f;

    private Vector3 initialSize;
    private Vector3 currentSize;
    private Vector3 targetSize;
    private void Start()
    {
        initialSize = transform.localScale;
        targetSize = new Vector3(0, 0, 0);
        StartCoroutine(ShrinkBullet());
    }
    protected override void SetBulletSpeed()
    {
        bulletSpeed = 10f;
    }
    IEnumerator ShrinkBullet()
    {
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(initialSize, targetSize, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetSize;
    }
}