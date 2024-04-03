using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; //Variable to get player rigidbody 2D
    public float playerSpeed = 5f; //Variable to set player speed
    float horInput, vertInput; //Variables to handle WASD controls
    Vector2 movement; //Variable to handle player movements
    public static bool playerDied = false; //Variable to track if player is alive

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Gets rigidbody 2D of player
    }

    //Function that moves player by a set speed depending on which keys are being pressed
    void FixedUpdate()
    {
        horInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        movement = new Vector2(horInput, vertInput);

        rb.velocity = movement * playerSpeed;
    }

    //Function that kills player if they collide with an enemy
    void OnTriggerEnter2D(Collider2D collision)
    {
        playerDied = true;
        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}