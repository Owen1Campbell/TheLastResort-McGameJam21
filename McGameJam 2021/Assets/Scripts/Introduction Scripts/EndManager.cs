using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{

    public GameObject obj; 
    
    public void OnDisable()
    {
        Debug.Log(this.gameObject.name);
        obj.GetComponent<BossManager>().EnableDialogue(this.gameObject.name);
    }

   
}
