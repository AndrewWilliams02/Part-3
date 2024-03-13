using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public override ChestType CanOpen()
    {
        return ChestType.Thieves;
    }
}
