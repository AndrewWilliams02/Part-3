using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    public TMPro.TextMeshProUGUI currentSelection;
    public static CharacterControl Instance;
    public static Villager SelectedVillager { get; private set; }

    public List<Villager> availableVillagers;
    public static void SetSelectedVillager(Villager villager)
    {
        if (SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        Instance.currentSelection.text = villager.ToString();
    }

    public void CharacterChanged(int index)
    {
        if (index >= 0 && index < availableVillagers.Count)
        {
            SetSelectedVillager(availableVillagers[index]);
        }
    }

    public void ChangeCharacterScale(float scale)
    {
        if (scale >= 0.5 && scale <= 2)
        {
            Villager.villagerScale = scale;
            SelectedVillager.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    private void Start()
    {
        Instance = this;
    }
}
