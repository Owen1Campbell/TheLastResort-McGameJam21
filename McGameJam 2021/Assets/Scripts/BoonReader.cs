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
                break;
            case "attack damage":
                player.damageMultiplier = (float)boon.modifier;
                break;
            case "damage resistance":

                break;
            case "max health":
                player.maximumHealth = (int)(player.maximumHealth * boon.modifier);
                break;
            case "soundtrack":

                break;
            case "glasses":

                break;
        }
    }
}
