using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fundamental : MonoBehaviour
{
    // Fundamentals for Coding and Operation.
    private Vector2 moveDirection;
    private Rigidbody2D playerBody2D;

    // Player Stats -- For Developer-level adjustment.
    public float    movementSpeed;
    public float    baseDamage;
    public int      maximumHealth;

    // Player Mods -- For in-game multiplicative adjustment.
    public float    movementMultiplier;
    public float    damageMultiplier;
    public int      currentHealth;

    // Initialization.
    void Start()
    {
        // Get Components
        playerBody2D = GetComponent<Rigidbody2D>();
    }

    // Once-per-frame.
    void Update()
    {
        // Take movement input and adjust the moveDirection vector.
        // For where movement occurs, see 'FixedUpdate()'.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(
            (horizontalInput * movementSpeed) * movementMultiplier,
            (verticalInput * movementSpeed) * movementMultiplier
        );
    }

    private void FixedUpdate()
    {
        playerBody2D.MovePosition(playerBody2D.position + moveDirection * Time.fixedDeltaTime);
    }
}
