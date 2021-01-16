using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boon
{
    public string effect;       // which value does the boon affect?
    public double modifier;     // value by which the corresponding stat is changed

    public bool luck;           // positive or negative?
                                // true is pos, false is neg
    public string message;      // description of effects
}
