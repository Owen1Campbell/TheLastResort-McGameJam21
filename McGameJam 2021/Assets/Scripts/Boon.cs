using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boon
{
    public int count;           // ids place in boon array, 0-3. 
                                // id corresponds to room in which the boon was acquired (0 comes at the end of the intro sequence)
    public string effect;       // which value does the boon affect?
    public double modifier;     // value by which the corresponding stat is changed

    public bool luck;           // positive or negative?
                                // true is pos, false is neg
    public string message;      // description of effects
}
