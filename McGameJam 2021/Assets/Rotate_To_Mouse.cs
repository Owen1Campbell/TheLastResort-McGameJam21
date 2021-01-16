using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_To_Mouse : MonoBehaviour
{
    // Initialization.
    void Start()
    {
        
    }

    // Once-per-frame.
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = -direction;
    }
}
