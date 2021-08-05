using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bullet : MonoBehaviour
{
    public BulletManager bulletManager;

    private void OnTriggerEnter(Collider other)
    {
        PartPoint point = other.GetComponent<PartPoint>();
        if (point && point.enabled)
        {
            switch (point.point.type)
            {
                case Point.PointType.Plus:
                    bulletManager.Add(point.point.value);
                    break;
                case Point.PointType.Minus:
                    bulletManager.Remove(point.point.value);
                    break;
                case Point.PointType.Divide:
                    bulletManager.Divide(point.point.value);
                    break;
                case Point.PointType.Multiply:
                    bulletManager.Multiply(point.point.value);
                    break;
                default:
                    break;
            }

            //BURAYI DEGISTIR
            point.SetItemStatus(false); ;
        }

    }
}

