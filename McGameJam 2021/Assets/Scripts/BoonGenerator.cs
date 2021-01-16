using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoonGenerator : MonoBehaviour
{
    public Boon posBoon, negBoon;

    private System.Random randm = new System.Random();

    private GameObject panel;

    private Text posText, negText;

    void OnEnable()
    {
        posBoon = Generate(true);
        negBoon = Generate(false);

        panel = transform.gameObject;
        posText = panel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
        posText.text = posBoon.message;
        negText = panel.transform.GetChild(1).GetChild(1).gameObject.GetComponent<Text>();
        negText.text = negBoon.message;
    }

    Boon Generate(bool posneg)
    {
        Boon boon = new Boon();
        int type = randm.Next(1, 7);
        Debug.Log(type);
        string incdec, plainTextMod;
        boon.luck = posneg;

        if (posneg)
        {
            incdec = "Increases ";
        }
        else
        {
            incdec = "Decreases ";
        }

        switch(type)
        {
            case 1: // speed boon
                boon.effect = "movement speed";
                boon.modifier = randm.NextDouble();
                boon.modifier = System.Math.Truncate(boon.modifier * 100) / 100;
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                if (posneg)
                {
                    boon.modifier += 1;
                    plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                }
                else
                {
                    boon.modifier = 1 - boon.modifier;
                    Debug.Log(boon.modifier);
                    plainTextMod = (int)((boon.modifier + 1) * 100) + "%";
                }
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 2: // attack damage
                boon.effect = "attack damage";
                boon.modifier = randm.NextDouble();
                boon.modifier = System.Math.Truncate(boon.modifier * 100) / 100;
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                if (posneg)
                {
                    boon.modifier += 1;
                    plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                }
                else
                {
                    boon.modifier = 1 - boon.modifier;
                    Debug.Log(boon.modifier);
                    plainTextMod = (int)((boon.modifier + 1) * 100) + "%";
                }
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 3: // dmg resist
                boon.effect = "damage resistance";
                boon.modifier = randm.NextDouble();
                boon.modifier = System.Math.Truncate(boon.modifier * 100) / 100;
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                if (posneg)
                {
                    boon.modifier += 1;
                    plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                }
                else
                {
                    boon.modifier = 1 - boon.modifier;
                    Debug.Log(boon.modifier);
                    plainTextMod = (int)((boon.modifier + 1) * 100) + "%";
                }
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 4: // max health
                boon.effect = "max health";
                boon.modifier = randm.NextDouble();
                boon.modifier = System.Math.Truncate(boon.modifier * 100) / 100;
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                if (posneg)
                {
                    boon.modifier += 1;
                    plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                }
                else
                {
                    boon.modifier = 1 - boon.modifier;
                    Debug.Log(boon.modifier);
                    plainTextMod = (int)((1 - boon.modifier) * 100) + "%";
                }
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 5: // soundtrack
                boon.effect = "soundtrack";
                if (posneg)
                {
                    boon.message = "Soundtrack gets bangin";
                    boon.modifier = 1;
                }
                else
                {
                    boon.message = "Soundtrack sucks now";
                    boon.modifier = 2;
                }
                Debug.Log(boon.message);
                break;
            case 6: // glasses
                boon.effect = "glasses";
                if (posneg)
                {
                    boon.message = "Equip sunglasses";
                    boon.modifier = 1;
                }
                else
                {
                    boon.message = "Get Groucho glasses";
                    boon.modifier = 2;
                }
                Debug.Log(boon.message);
                break;
        }

        return boon;
    }

    public void posButton()
    {
        StashAndGrab(posBoon);
    }

    public void negButton()
    {
        StashAndGrab(negBoon);
    }

    private void StashAndGrab(Boon buttonBoon)
    {
        BoonManager.Instance.boonList[BoonManager.Instance.boonListPos] = buttonBoon;
        BoonManager.Instance.boonListPos++;

        Boon newBoon = Generate(!buttonBoon.luck);

        BoonManager.Instance.boonList[BoonManager.Instance.boonListPos] = newBoon;
        BoonManager.Instance.boonListPos++;

        BoonManager.Instance.hasBoons = true;
    }
}
