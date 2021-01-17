using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Queue<string> sentences;

    public GameObject playInterface;
    public GameObject dialogueInterface;
    private GameObject nameBox;
    public GameObject element;

    public Dialogue dialogue;

    private string characterName;

    private Color originalColor;

   // public AudioSource ClickSound;
   // private GameObject audioIntro, audioLoop;

   // public GameObject particleContainer;

    public void EnableDialogue()
    {
        characterName = "???";
        nameBox = dialogueInterface.transform.GetChild(3).gameObject;
        playInterface.SetActive(false);
        dialogueInterface.SetActive(true);
        StartCoroutine("fadeElement");
        //SplashSound.Play();
        //PlayMusic();
                    
        //particleContainer.transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        //ReadDialogue("Introduction");                       
    }

    // Start is called before the first frame update
    void Start()
    {
        originalColor = element.GetComponent<Image>().color;
        sentences = new Queue<string>();
    }
    public void ReadDialogue(string fileName)
    {
        //string file = ("Dialogue/" + fileName).Substring(0, ("Dialogue/" + fileName).Length - 4);
        dialogue.sentences = Resources.Load<TextAsset>(fileName).text.Split("\n"[0]);
        dialogue.name = characterName;

        StartDialogue(dialogue);
    }
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        int i;

        if (sentences.Count == 0)
        {
            DisableDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        nameBox.SetActive(false);
        
        // check for name flags at the beginnings of sentences
        if (sentence[0] == ':')
        {
            nameBox.SetActive(true);
            i = 1;
            while (sentence[i] != ':')
            {
                i++;
            }
            nameText.text = sentence.Substring(1, i - 1);
            // if name is empty, disable name box to imply narrator speech
            if (nameText.text == " ")
            {
                nameBox.SetActive(false);
            }
            else
            {
                nameBox.SetActive(true);
            }
            // stop coroutines to prevent overlap of two letter typers when clicking through too fast
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence.Substring(i - 1 + 2)));
        }
        else if (sentence[0] == ';')
        {
            nameBox.SetActive(true);
            i = 1;
            while (sentence[i] != ';')
            {
                i++;
            }
            nameText.text = sentence.Substring(1, i - 1);
            // if name is empty, disable name box to imply narrator speech
            if (nameText.text == " ")
            {
                nameBox.SetActive(false);
            }
            else
            {
                nameBox.SetActive(true);
            }

            if (nameText.text == "Casino")
            {
                nameBox.SetActive(false);
                dialogueInterface.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            }
            else if (nameText.text == "Figure")
            {
                dialogueInterface.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            }
            else if (nameText.text == "DisableFigure")
            {
                nameBox.SetActive(false);
                dialogueInterface.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            }
            else if (nameText.text == "Stranger")
            {
                dialogueInterface.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            }
            else if (nameText.text == "???")
            {
                nameBox.SetActive(true);
                dialogueInterface.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
            }
            else if (nameText.text == "Jules")
            {
                nameBox.SetActive(true);
                dialogueInterface.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
            }
            // stop coroutines to prevent overlap of two letter typers when clicking through too fast


            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence.Substring(i - 1 + 2)));
        }
        else
        {
            // if no name flag, reset name to characterName
            // this allows you to not have to reflag every line
            nameText.text = characterName;
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    public void DisableDialogue()
    {
        AudioListener.pause = false;
        dialogueInterface.transform.GetChild(0).GetComponent<Image>().color = originalColor;
        dialogueInterface.SetActive(false);
        
    }

   

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
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
        dialogueInterface.transform.GetChild(2).gameObject.SetActive(true);
        dialogueInterface.transform.GetChild(3).gameObject.SetActive(true);
        ReadDialogue("Introduction");
    }


}
