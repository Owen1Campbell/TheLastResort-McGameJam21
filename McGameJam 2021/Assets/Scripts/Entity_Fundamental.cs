using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Fundamental : MonoBehaviour
{
    // Fundamentals for Coding and Operation.
    private Rigidbody2D entityBody2D;

    // Entity Stats -- For Developer-level adjustment.
    public float movementSpeed;
    public float baseDamage;
    public int maximumHealth;

    // Entity Mods -- For in-game multiplicative adjustment.
    public float movementMultiplier;
    public float damageMultiplier;
    public int currentHealth;

    // Initialization.
    void Start()
    {
        // N/A.
    }

    // Once-per-frame.
    void Update()
    {
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
