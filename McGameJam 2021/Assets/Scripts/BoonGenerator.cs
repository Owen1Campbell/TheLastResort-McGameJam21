using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoonGenerator : MonoBehaviour
{
    public Boon posBoon, negBoon;

    private System.Random randm = new System.Random();

    private int posRand, negRand;

    private GameObject panel;

    private Text posText, negText;

    void OnEnable()
    {
        posRand = randm.Next(1, 7);
        negRand = randm.Next(1, 7);
        Debug.Log(posRand);
        Debug.Log(negRand);
        posBoon = Generate(posRand, true);
        negBoon = Generate(negRand, false);

        panel = transform.gameObject;
        posText = panel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>();
        posText.text = posBoon.message;
        negText = panel.transform.GetChild(1).GetChild(1).gameObject.GetComponent<Text>();
        negText.text = negBoon.message;
    }

    Boon Generate(int type, bool posneg)
    {
        Boon boon = new Boon();
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
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                boon.modifier += 1;
                plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 2: // attack damage
                boon.effect = "attack damage";
                boon.modifier = randm.NextDouble();
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                boon.modifier += 1;
                plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 3: // dmg resist
                boon.effect = "damage resistance";
                boon.modifier = randm.NextDouble();
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                boon.modifier += 1;
                plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 4: // atk speed
                boon.effect = "attack speed";
                boon.modifier = randm.NextDouble();
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                boon.modifier += 1;
                plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 5: // max health
                boon.effect = "max health";
                boon.modifier = randm.NextDouble();
                if (boon.modifier > 0.5)
                {
                    boon.modifier = boon.modifier - 0.5;
                }
                if (boon.modifier < 0.1)
                {
                    boon.modifier = boon.modifier + 0.1;
                }
                boon.modifier += 1;
                plainTextMod = (int)((boon.modifier - 1) * 100) + "%";
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 6: // soundtrack
                boon.effect = "soundtrack";
                boon.modifier = 0;
                if (posneg)
                {
                    boon.message = "Soundtrack gets bangin";
                }
                else
                {
                    boon.message = "Soundtrack sucks now";
                }
                Debug.Log(boon.message);
                break;
            case 7: // glasses
                if (posneg)
                {
                    boon.message = "Equip sunglasses";
                }
                else
                {
                    boon.message = "Get Groucho glasses";
                }
                Debug.Log(boon.message);
                break;
        }

        return boon;
    }
}
