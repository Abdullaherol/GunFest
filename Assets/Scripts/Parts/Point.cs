using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Point
{
    public PointType type;
    [Range(1,100)]
    public int value;

    public enum PointType
    {
        Plus,
        Minus,
        Divide,
        Multiply
    }    
}

