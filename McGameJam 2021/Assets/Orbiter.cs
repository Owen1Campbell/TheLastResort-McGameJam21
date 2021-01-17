using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    public GameObject axisObject;
    public float degreesPerSecond;

    private int rotationMultiplier = 1;

    // Components this can work with:\
    private Rigidbody2D entityBody;

    // Start is called before the first frame update
    void Start()
    {
        // Read in from other component(s), if any.
        entityBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(axisObject.transform.position, Vector3.forward, degreesPerSecond * rotationMultiplier * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(rotationMultiplier == 1)
        {
            rotationMultiplier = -1;
        } else {
            rotationMultiplier = 1;
        }
    }
}
