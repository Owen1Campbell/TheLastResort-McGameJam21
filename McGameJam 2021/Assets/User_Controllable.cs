using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_Controllable : MonoBehaviour
{
    // Fundamentals for Operation.
    private Vector2 moveDirection;

    public GameObject projectilePrefab;

    // Components this can work with:
    private Entity_Fundamental entityBase;
    private Rigidbody2D entityBody;

    // Initialization.
    void Start()
    {
        // Read in from other component(s), if any.
        entityBase = GetComponent<Entity_Fundamental>();
        entityBody = GetComponent<Rigidbody2D>();
    }

    // Once-per-frame.
    void Update()
    {

        // Take movement input and adjust the moveDirection vector.
        // For where movement occurs, see 'FixedUpdate()'.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (entityBase != null)
        {
            moveDirection = new Vector2(
                (horizontalInput * entityBase.movementSpeed) * entityBase.movementMultiplier,
                (verticalInput * entityBase.movementSpeed) * entityBase.movementMultiplier
            );
        } else {
            // Default movement.
            moveDirection = new Vector2(horizontalInput, verticalInput);
        }

        // Take left mouse input and fire a projectile.
        if(Input.GetMouseButtonDown(0))
        {
            if (entityBase != null)
            {
                // Take stats from the entity base if available.
                GameObject projectile = Instantiate<GameObject>(projectilePrefab);
                projectile.transform.position = transform.position - (transform.up * 0.5f);
                projectile.transform.rotation = transform.rotation;

                // Apply direction to it.
                Projectile projectileStats = projectile.GetComponent<Projectile>();
                projectileStats.movementSpeed = entityBase.movementSpeed;
                projectileStats.movementMultiplier = entityBase.movementMultiplier * 1.5f;
                projectileStats.moveDirection = -transform.up;

                // Apply damage and duration.
                projectileStats.baseDamage = entityBase.baseDamage;
                projectileStats.damageMultiplier = entityBase.damageMultiplier;
                projectileStats.projectileDuration = 0.1f;
            }
        }
    }

    private void FixedUpdate()
    {
        if(entityBody != null)
        {
            entityBody.MovePosition(entityBody.position + moveDirection * Time.fixedDeltaTime);
        }
    }
}
