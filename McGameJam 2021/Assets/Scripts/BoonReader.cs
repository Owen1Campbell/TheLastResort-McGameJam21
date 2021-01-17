using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonReader : MonoBehaviour
{
    private Entity_Fundamental player;

    void Awake()
    {
        GetBoons();
        
    }

    void OnEnable()
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

        Debug.Log("getting boons");
        Debug.Log("boonListPos: " + BoonManager.Instance.boonListPos);

        // apply each boon
        if (BoonManager.Instance.hasBoons)
        {
            Debug.Log("in if; has boons");
            for (int i = 0; i <= BoonManager.Instance.boonListPos - 1; i++)
            {
                Debug.Log("reading boons[" + i + "]");
                ApplyBoon(BoonManager.Instance.boonList[i]);
            }
        }
    }

    void ApplyBoon(Boon boon)
    {
        switch(boon.effect)
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
