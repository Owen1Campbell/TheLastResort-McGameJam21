using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroBoonEnd : MonoBehaviour
{
    void OnDisable()
    {
        SceneManager.LoadScene("Room1");
    }
}
