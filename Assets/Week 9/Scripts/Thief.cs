using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knfie1, knife2;
    public Transform spawn1, spawn2;

    protected override void Attack()
    {
        destination = transform.position + new Vector3((2 * direction), 0, 0);
        base.Attack();
        Instantiate(knfie1, spawn1.position, spawn1.rotation);
        Instantiate(knife2, spawn2.position, spawn2.rotation);
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thieves;
    }
}
