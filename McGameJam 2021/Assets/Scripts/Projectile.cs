using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Fundamentals for Coding and Operation.
    private Rigidbody2D projectileBody2D;

    // Projectile Stats -- Managed and set by whatever creates the projectile.
    public float movementSpeed;
    public float baseDamage;
    public float projectileDuration;
    public Vector2 moveDirection;

    public string origin;

    // Projectile Mods
    public float movementMultiplier;
    public float damageMultiplier;

    // Initialization.
    void Start()
    {
        // Get Component(s).
        projectileBody2D = GetComponent<Rigidbody2D>();

        // Invoke self-destruct after a particular time if time is set.
        if (projectileDuration > 0)
        {
            Invoke("SelfDestruct", projectileDuration);
        }
    }

    // Once-per-frame.
    void Update()
    {
        // N/A.
    }

    private void FixedUpdate()
    {
        float finalSpeed = movementSpeed * movementMultiplier;
        projectileBody2D.MovePosition(projectileBody2D.position + moveDirection * finalSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Inflict damage to the recipient if they can feel pain.
        Entity_Fundamental otherEntity = other.gameObject.GetComponent<Entity_Fundamental>();
        if (otherEntity != null && other.gameObject.name != origin)
        {
            Debug.Log("Hit!  Entity hit had " + otherEntity.currentHealth + " health!");
            otherEntity.currentHealth = Math.Max(0, otherEntity.currentHealth - (int) (baseDamage * damageMultiplier));
            Debug.Log("Now entity has " + otherEntity.currentHealth + " health!");
        }

        SelfDestruct();
    }

    // To be called after a particular amount of time, if needed.
    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
