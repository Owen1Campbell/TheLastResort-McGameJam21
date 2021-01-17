using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChip : MonoBehaviour
{
    public GameObject chip;

    // Update is called once per frame
    void Update()
    {
        if (Enemies.Count == 0)
        {
            chip.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
