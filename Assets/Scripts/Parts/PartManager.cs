using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PartManager : MonoBehaviour
{
    public List<Part> parts= new List<Part>();

    public int GetTotalRequireAmount()
    {
        int amount = 0;
        for (int i = 0; i < parts.Count; i++)
        {
            Part part = parts[i];
            amount += part.GetRequireAmount(amount);
        }
        return amount;
    }
}
