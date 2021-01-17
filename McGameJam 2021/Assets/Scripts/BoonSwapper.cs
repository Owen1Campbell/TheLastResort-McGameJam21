using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonSwapper : MonoBehaviour
{
    private Entity_Fundamental player;

    void Awake()
    {
        GetBoons();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GetBoons()
    {
        // assign player to allow modification of values
        player = GetComponent<Entity_Fundamental>();

        // apply each boon
        if (BoonManager.Instance.hasBoons)
        {
            for (int i = 0; i <= BoonManager.Instance.boonListPos; i++)
            {
                SwapBoon(BoonManager.Instance.boonList[i]);
            }
        }
    }

    void SwapBoon(Boon boon)
    {
        switch (boon.effect)
        {
            case "soundtrack": // for these two: 1 is pos, 2 is neg
            case "glasses":
                if (boon.modifier == 1)
                    boon.modifier = 2;
                else
                    boon.modifier = 1;
                break;
            case "movement speed":
            case "attack damage":
            case "max health":
                if (boon.luck)  // positive to negative 
                {
                    boon.modifier = 2 - boon.modifier;
                }
                else            // negative to positive
                {
                    boon.modifier = (1 - boon.modifier) + 1;
                }
                break;
        }
        ApplyBoon(boon);
    }
    void ApplyBoon(Boon boon)
    {
        switch (boon.effect)
        {
            case "movement speed":
                player.movementMultiplier = (float)boon.modifier;
                Debug.Log("boon/player" + (float)boon.modifier + " " + player.movementMultiplier);
                break;
            case "attack damage":
                player.damageMultiplier = (float)boon.modifier;
                Debug.Log("boon/player" + (float)boon.modifier + " " + player.damageMultiplier);
                break;
            case "damage resistance":

                break;
            case "max health":
                player.maximumHealth = (int)(player.maximumHealth * boon.modifier);
                if (boon.luck)
                {
                    int healthMod = player.maximumHealth - 30;
                    player.currentHealth += healthMod;
                }
                if (player.currentHealth > player.maximumHealth)
                {
                    player.currentHealth = player.maximumHealth;
                }
                Debug.Log("boon/player" + (float)boon.modifier + " " + player.maximumHealth);
                break;
            case "soundtrack":

                break;
            case "glasses":

                break;
        }
    }
}
