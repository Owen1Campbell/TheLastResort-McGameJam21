using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipScript : MonoBehaviour
{
    public GameObject panel;

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            panel.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
