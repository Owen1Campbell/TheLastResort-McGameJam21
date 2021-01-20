using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Entity_Fundamental player;
    public Text barDisplay;
    public Slider bar;

    // Update is called once per frame
    void Update()
    {
        barDisplay.text = player.currentHealth + " / " + player.maximumHealth;
        bar.maxValue = player.maximumHealth;
        bar.value = player.currentHealth;
    }
}
