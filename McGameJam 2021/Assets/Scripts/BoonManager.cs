using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoonManager : MonoBehaviour
{
    private static BoonManager _instance;

    public static BoonManager Instance
    {
        get
        {
            // create instance
            if (_instance == null)
            {
                GameObject boons = new GameObject("BoonManager");
                boons.AddComponent<BoonManager>();
            }

            return _instance;
        }
    }

    public Boon[] boonList = new Boon[4];   // array to store boons
    public int boonListPos;                 // position in boon list. should be the same as the room the player is in

    void Awake()
    {
        _instance = this;
    }
}
