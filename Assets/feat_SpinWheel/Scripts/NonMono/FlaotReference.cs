using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FloatReference
{
    public bool useConstant = true;
    public float Constantvalue;
    public FloatVariable Variable;

    public float Value
    {
        get { return useConstant ? Constantvalue : Variable.value; }
    }

}
