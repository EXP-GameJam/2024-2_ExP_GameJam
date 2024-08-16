using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    /// <summary>
    /// string을 Split하면서 자동으로 Trim해주는 Extension
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static string[] TrimSplit(this string s, string c)
    {
        string[] splitS = s.Split(c);
        for(int i = 0; i < splitS.Length; i++)
            splitS[i] = splitS[i].Trim();
        return splitS;
    }
}