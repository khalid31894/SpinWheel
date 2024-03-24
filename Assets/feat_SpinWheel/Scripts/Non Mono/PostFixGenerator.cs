using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PostFixGenerator
{
    public static string AddPostfix(int value)
    {
        if (value >= 1000000000)
        {
            return (value / 1000000000f).ToString("F2") + "B"; // Billion
        }
        else if (value >= 1000000)
        {
            return (value / 1000000f).ToString("F2") + "M"; // Million
        }
        else if (value >= 1000)
        {
            return (value / 1000f).ToString("F2") + "K"; // Thousand
        }
        else
        {
            return value.ToString();
        }
    }
}
