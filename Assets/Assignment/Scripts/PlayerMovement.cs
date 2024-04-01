using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed = 5f;
    float horInput, vertInput;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        horInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        movement = new Vector2(horInput, vertInput);

        rb.velocity = movement * playerSpeed;
    }
}