using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fundamental : MonoBehaviour
{
    // Fundamentals for Coding and Operation.
    private Rigidbody2D projectileBody2D;

    // Projectile Stats -- Managed and set by whatever creates the projectile.
    public float movementSpeed;
    public float baseDamage;
    public float projectileDuration;
    public Vector2 moveDirection;

    // Projectile Mods
    public float movementMultiplier;
    public float damageMultiplier;

    // Initialization.
    void Start()
    {
        // Get Components
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
        projectileBody2D.MovePosition(projectileBody2D.position + moveDirection * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Inflict damage to the recipient if they can feel pain.
        // TODO

        // Self destruct after the projectile hits anything.
        SelfDestruct();
    }

    // To be called after a particular amount of time, if needed.
    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
