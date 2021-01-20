using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDisableOpenBoon : MonoBehaviour
{
    public GameObject boonBox;
    void OnDisable()
    {
        boonBox.SetActive(true);
    }
}
