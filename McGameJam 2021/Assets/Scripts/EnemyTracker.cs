using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    void OnEnable()
    {
        Enemies.Count++;
    }

    void OnDisable()
    {
        Enemies.Count--;
    }
}
