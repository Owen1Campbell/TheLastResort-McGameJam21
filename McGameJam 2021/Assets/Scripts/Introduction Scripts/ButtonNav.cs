using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNav : MonoBehaviour
{
    public GameObject credits;
    public GameObject element;

    private Color originalColor;

    public IntroductionManager intromanager;
    public AudioSource music;

    public AudioSource chip;
    public void StartGame()
    {
        //Debug.Log("DEBUG: Introduction scene not done yet.");
        intromanager.EnableDialogue();
        chip.Play();
        music.PlayDelayed(chip.clip.length);
        //SceneManager.LoadScene("Hub");
    }

    public void ShowCredits()
    {
        chip.Play();
        StartCoroutine("fadeElement");
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        chip.Play();
        element.GetComponent<Image>().color = originalColor;
        credits.SetActive(false);
    }

    public IEnumerator fadeElement()
    {
        var tempColor = element.GetComponent<Image>().color;
        originalColor = tempColor;
        while (element.GetComponent<Image>().color.a < .729f)
        {
            tempColor = new Color(tempColor.r, tempColor.g, tempColor.b, tempColor.a + (Time.deltaTime / 1.0f));
            element.GetComponent<Image>().color = tempColor;
            yield return null;
        }
    }

}
