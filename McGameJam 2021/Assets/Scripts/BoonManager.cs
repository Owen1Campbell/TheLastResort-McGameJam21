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

    public Boon[] boonList = new Boon[8];   // array to store boons
    public int boonListPos;                 // position in boon list. should be the same as the room the player is in
    public int chosen;                      // add for positives, subtract for negatives. if it ends positive, lady luck, negative miss fortune
                                            // if necessary, coin flip at 0
    public bool hasBoons;                   // just in case
    public bool glassesChanged;
    public bool musicChanged;               // if music or glasses change, other random boons wont change them back

    void Awake()
    {
        _instance = this;
    }
}
