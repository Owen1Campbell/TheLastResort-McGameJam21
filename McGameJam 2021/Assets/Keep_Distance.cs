using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keep_Distance : MonoBehaviour
{
    public GameObject targetObject;

    // Components this can work with:
    private Entity_Fundamental entityBase;

    // Start is called before the first frame update
    void Start()
    {
        // Read in from other component(s), if any.
        entityBase = GetComponent<Entity_Fundamental>();
    }

    // Update is called once per frame
    void Update()
    {
        if(entityBase != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, );
        }
    }
}
