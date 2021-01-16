using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_Controllable : MonoBehaviour
{
    // Fundamentals for Operation.
    private Vector2 moveDirection;

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
            moveDirection = new Vector2(horizontalInput, verticalInput);
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
