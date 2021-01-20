using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enemies
{
    private static int count;

    public static int Count
    {
        get
        {
            return count;
        }
        set
        {
            count = value;
        }
    }
}
