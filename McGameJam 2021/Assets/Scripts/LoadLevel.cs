using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel: MonoBehaviour
{
    [SerializeField]
    public string room; // allows entering of string in component manager

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            // if player enters, loads scene "room"
            SceneManager.LoadScene(room);
        }
    }
}
