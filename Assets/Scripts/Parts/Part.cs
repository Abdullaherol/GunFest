using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Part : MonoBehaviour
{
    public PartPoint[] partPoints;
    [HideInInspector]
    public Vector2 size;
    [HideInInspector]
    public Vector3 direction;

    private void Start()
    {
        direction = partPoints[0].transform.forward * -1;
        size = transform.localScale;
    }

    public int GetRequireAmount(int currentValue)
    {
        PartPoint biggest = partPoints.Where(x=>x.point.type == Point.PointType.Plus || x.point.type == Point.PointType.Multiply).FirstOrDefault();
        if (biggest == null)
            return 0;
        foreach (var item in partPoints)
        {
            Point.PointType type = item.GetPointType();

            if (type == Point.PointType.Plus)
            {
                if (biggest.GetPointType() == Point.PointType.Plus)
                {
                    if (biggest.GetPointValue() < item.GetPointValue()) biggest = item;
                }
                else if (biggest.GetPointType() == Point.PointType.Multiply)
                    if (biggest.GetPointValue() * currentValue < item.GetPointValue() + currentValue)
                        biggest = item;
            }
            else if(type == Point.PointType.Multiply)
            {
                if (biggest.GetPointType() == Point.PointType.Plus)
                {
                    if (item.GetPointValue() * currentValue > biggest.GetPointValue() + currentValue)
                        biggest = item;
                }
                else if (biggest.GetPointType() == Point.PointType.Multiply)
                    if (biggest.GetPointValue() * currentValue < item.GetPointValue() * currentValue)
                        biggest = item;
            }

        }
        if (biggest.GetPointType() == Point.PointType.Multiply)
            return (biggest.GetPointValue()-1) * currentValue;
        else 
            return biggest.GetPointValue();
    }

    public void SetPointsStatus(bool status)
    {
        foreach (var item in partPoints)
        {
            item.enabled = status;
        }
    }
}
