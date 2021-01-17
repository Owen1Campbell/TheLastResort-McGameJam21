using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Autofire : MonoBehaviour
{
    // Components this can work with:
    private Entity_Fundamental entityBase;
    private Rigidbody2D entityBody;

    public float frequency_in_seconds;

    public GameObject projectilePrefab;

    // Initialization
    void Start()
    {
        // Read in from other component(s), if any.
        entityBase = GetComponent<Entity_Fundamental>();
        entityBody = GetComponent<Rigidbody2D>();

        // Invoke Autofire.
        InvokeRepeating("FireProjectile", frequency_in_seconds, frequency_in_seconds);
    }

    // Once-per-frame.
    void Update()
    {
        
    }

    void FireProjectile()
    {
        if (entityBase != null)
        {
            // Take stats from the entity base if available.
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = transform.position - (transform.up);
            projectile.transform.rotation = transform.rotation;

            // Apply direction to it.
            Projectile projectileStats = projectile.GetComponent<Projectile>();
            projectileStats.movementSpeed = entityBase.movementSpeed;
            projectileStats.movementMultiplier = entityBase.movementMultiplier * 1.5f;
            projectileStats.moveDirection = -transform.up;

            // Apply damage and duration.
            projectileStats.baseDamage = entityBase.baseDamage;
            projectileStats.damageMultiplier = entityBase.damageMultiplier;
        }
    }
}
