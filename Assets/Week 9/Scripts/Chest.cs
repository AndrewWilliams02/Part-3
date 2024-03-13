using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ChestType { Villager, Merchant, Archer, Thieves }
public class Chest : MonoBehaviour
{
    public ChestType whoCanOpen;
    public Animator animator;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Villager>(out Villager villager))
        {
            if (villager.CanOpen() == whoCanOpen || whoCanOpen == ChestType.Villager)
            {
                animator.SetBool("IsOpened", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("IsOpened", false);
    }
}
