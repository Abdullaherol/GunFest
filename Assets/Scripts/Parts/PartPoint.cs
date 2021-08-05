using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PartPoint : MonoBehaviour
{
    public Part part;
    public Point point;
    public Image background;
    public TMPro.TextMeshProUGUI text;


#if UNITY_EDITOR
    private void Update()
    {
        switch (point.type)
        {
            case Point.PointType.Plus:
                background.color = new Color32(112,150,255,100);
                text.text = "+" + point.value;
                break;
            case Point.PointType.Minus:
                background.color = new Color32(241, 40, 51, 100);
                text.text = "-" + point.value;
                break;
            case Point.PointType.Divide:
                background.color = new Color32(241, 40, 51, 100);
                text.text = "÷" + point.value;
                break;
            case Point.PointType.Multiply:
                background.color = new Color32(112, 150, 255, 100);
                text.text = "×" + point.value;
                break;
            default:
                break;
        }
    }

    public IEnumerable<PartPoint> GetPartPoints()
    {
        //TODO DEGISTIR
        return transform.parent.GetComponentsInChildren<PartPoint>();
    }

    public void SetItemStatus(bool v)
    {
        part.SetPointsStatus(false);
    }

    public Point.PointType GetPointType()
    {
        return point.type;
    }

    public int GetPointValue()
    {
        return point.value;
    }
}
#endif
