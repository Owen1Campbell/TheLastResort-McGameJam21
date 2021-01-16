using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonReader : MonoBehaviour
{
    private Entity_Fundamental player;

    void Awake()
    {
        player = GetComponent<Entity_Fundamental>();

        for (int i = 0; i <= BoonManager.Instance.boonListPos; i++)
        {
            ApplyBoon(BoonManager.Instance.boonList[i]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }
}
