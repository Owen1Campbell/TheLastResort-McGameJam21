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
                ApplyBoon(BoonManager.Instance.boonList[i]);
            }
        }
    }

    void ApplyBoon(Boon boon)
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
                boon.modifier = SwapMod(boon.modifier);
                player.movementMultiplier = (float)boon.modifier;
                break;
            case "attack damage":
                boon.modifier = SwapMod(boon.modifier);
                player.damageMultiplier = (float)boon.modifier;
                break;
            case "max health":
                boon.modifier = SwapMod(boon.modifier);
                player.maximumHealth = (int)(player.maximumHealth * boon.modifier);
                break;
        }
    }

    double SwapMod(double mod)
    {

        return mod;
    }


}
