using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntRoundExtension
{
    public static int RoundOff(int i)
    {
        return ((int)Math.Round(i / 10.0)) * 10;
    }
}
