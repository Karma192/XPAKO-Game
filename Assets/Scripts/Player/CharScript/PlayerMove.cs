using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed;

    private Rigidbody2D rb;
    private float Timefixed;
    private Vector2 movement;
    private PlayerStats PS;

    void Start()
    {
        PS = gameObject.GetComponent<PlayerStats>();
        playerSpeed = PS.moveSpeed;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    public void Slow(int slow)
    {
        if (playerSpeed > slow)
        {
           playerSpeed -= slow; 
        }
        
    }
}
