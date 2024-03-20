using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    Coroutine dashing;
    protected override void Attack()
    {
        if (dashing != null)
        {
            StopCoroutine(dashing);

        }
        dashing = StartCoroutine(Dash());
    }
    IEnumerator Dash()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 7;
        while (speed > 3)
        {
            yield return null;
        }

        base.Attack();
        //makes the knives be thrown seperately one after another after the timer 0.1
        yield return new WaitForSeconds(0.1f);
        Instantiate(knifePrefab, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
    public override string ToString()
    {
        return "Hi I'm Bob!";
    }
}
