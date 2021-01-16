using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    public GameObject axisObject;
    public float degreesPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(axisObject.transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime);
    }
}
