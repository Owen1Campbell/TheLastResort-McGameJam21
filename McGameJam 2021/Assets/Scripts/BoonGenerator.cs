using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoonGenerator : MonoBehaviour
{
    public Boon posBoon, negBoon;

    private System.Random randm = new System.Random();

    private GameObject panel;

    private Text posText, negText, posBonus, negBonus;

    public GameObject exitFence, exitGate, player;

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
        int type = randm.Next(1, 6);
        if (BoonManager.Instance.glassesChanged)
        {
            while (type == 4)
            {
                type = randm.Next(1, 5);
            }
        }
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
                    plainTextMod = (int)((1 - boon.modifier) * 100) + "%";
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
                    plainTextMod = (int)((1 - boon.modifier) * 100) + "%";
                }
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 3: // max health
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
                    plainTextMod = (int)((1 - boon.modifier) * 100) + "%";
                }
                boon.message = incdec + boon.effect + " by " + plainTextMod;
                Debug.Log(boon.message);
                break;
            case 4: // glasses
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
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
        panel.transform.GetChild(1).gameObject.SetActive(false);
        posBonus = panel.transform.GetChild(0).GetChild(3).gameObject.GetComponent<Text>();
        posBonus.text = BoonManager.Instance.boonList[BoonManager.Instance.boonListPos-1].message;
        BoonManager.Instance.chosen++;
        StartCoroutine(movePosButt());
    }

    public void negButton()
    {
        StashAndGrab(negBoon);
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
        panel.transform.GetChild(0).gameObject.SetActive(false);
        negBonus = panel.transform.GetChild(1).GetChild(3).gameObject.GetComponent<Text>();
        negBonus.text = BoonManager.Instance.boonList[BoonManager.Instance.boonListPos - 1].message;
        BoonManager.Instance.chosen--;
        StartCoroutine(moveNegButt());
    }

    private void StashAndGrab(Boon buttonBoon)
    {
        BoonManager.Instance.boonList[BoonManager.Instance.boonListPos] = buttonBoon;
        BoonManager.Instance.boonListPos++;

        if (buttonBoon.effect == "soundtrack")
        {
            BoonManager.Instance.musicChanged = true;
        }

        if (buttonBoon.effect == "glasses")
        {
            BoonManager.Instance.glassesChanged = true;
        }

        Boon newBoon = Generate(!buttonBoon.luck);

        BoonManager.Instance.boonList[BoonManager.Instance.boonListPos] = newBoon;
        BoonManager.Instance.boonListPos++;

        BoonManager.Instance.hasBoons = true;
    }

    private IEnumerator movePosButt()
    {
        Transform butto = panel.transform.GetChild(0);
        while (butto.position.x < 500)
        {
            butto.position += new Vector3(300 * Time.deltaTime, 0, 0);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        panel.SetActive(false);
        exitFence.SetActive(false);
        exitGate.SetActive(true);
        player.SetActive(false);
        player.SetActive(true);
    }

    private IEnumerator moveNegButt()
    {
        Transform butto = panel.transform.GetChild(1);
        while (butto.position.x > 500)
        {
            butto.position -= new Vector3(300 * Time.deltaTime, 0, 0);
            yield return null;
        }
        yield return new WaitForSeconds(2);
        panel.SetActive(false);
        exitFence.SetActive(false);
        exitGate.SetActive(true);
        player.SetActive(false);
        player.SetActive(true);
    }
}
