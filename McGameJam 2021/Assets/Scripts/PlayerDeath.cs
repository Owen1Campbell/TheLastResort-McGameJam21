using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject endScreen;

    public void OnDisable()
    {
        if (this.GetComponent<Entity_Fundamental>().currentHealth == 0)
        {
            endScreen.SetActive(true);
        }
        
    }
}
