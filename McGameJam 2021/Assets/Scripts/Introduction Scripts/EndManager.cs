using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{

    public GameObject obj;
    public AudioSource sfx;
    public AudioClip playerDeath;
    public AudioClip bossDeath;
    
    public void OnDisable()
    {
        //Debug.Log(this.gameObject.name);

        if (this.gameObject.name == "Siren of Fortune")
        {
          sfx.PlayOneShot(bossDeath, .7f);
        } else if (this.gameObject.name == "Player")
        {
          sfx.PlayOneShot(playerDeath, .7f);
        }


        obj.GetComponent<BossManager>().EnableDialogue(this.gameObject.name);
    }

   
}
