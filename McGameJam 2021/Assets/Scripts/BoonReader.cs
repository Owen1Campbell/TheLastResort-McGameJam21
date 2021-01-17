using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonReader : MonoBehaviour
{
    private Entity_Fundamental player;
    //private Sprite jules;
    public Sprite sunglasses, groucho;

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
        //jules = GetComponent<SpriteRenderer>().sprite;

        Debug.Log("getting boons");
        Debug.Log("number of boons: " + BoonManager.Instance.boonListPos);

        // apply each boon
        if (BoonManager.Instance.hasBoons)
        {
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
                break;
            case "attack damage":
                player.damageMultiplier = (float)boon.modifier;
                break;
            case "max health":
                player.maximumHealth = (int)(player.maximumHealth * boon.modifier);
                player.currentHealth = player.maximumHealth;
                break;
            case "soundtrack":

                break;
            case "glasses":
                // 1 is sunglasses, 2 is nose glasses
                if (boon.modifier == 1)
                {
                    GetComponent<SpriteRenderer>().sprite = sunglasses;
                }
                else if (boon.modifier == 2)
                {
                    GetComponent<SpriteRenderer>().sprite = groucho;
                }
                break;
        }
    }
}
