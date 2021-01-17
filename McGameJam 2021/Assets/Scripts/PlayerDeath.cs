using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject endScreen;

    public void OnDisable()
    {
        endScreen.SetActive(true);
    }
}
