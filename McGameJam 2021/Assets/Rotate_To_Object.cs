using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_To_Object : MonoBehaviour
{
    public GameObject focalObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this != null) { 
        Vector2 direction = new Vector2(
            focalObject.transform.position.x - transform.position.x,
            focalObject.transform.position.y - transform.position.y
        );

        transform.up = -direction;
        }
    }
}
