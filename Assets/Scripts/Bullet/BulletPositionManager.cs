using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPositionManager : MonoBehaviour
{

    public BulletManager bulletManager;
    public List<Bullet> activeBullets = new List<Bullet> ();
    
    [Range(3, 20)]
    public int startAmount = 4;
    private int amount;
    public Vector2 space = new Vector2(1,1);

    public float spawnDuration = 0.05f;
    public float removeDuration = 0.05f;

    public void Add(int amount)
    {
        StartCoroutine(AddSmooth(amount));
    }

    private IEnumerator AddSmooth(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            activeBullets.Add(bulletManager.bullets[0]);
            yield return new WaitForSeconds(spawnDuration);
        }
    }

    private IEnumerator RemoveSmooth(int amount) 
    {
        if (activeBullets.Count > amount)
        {
            for (int i = 0; i < amount; i++)
            {
                activeBullets.RemoveAt(activeBullets.Count-1);
                yield return new WaitForSeconds(removeDuration);
            }
        }
        else Debug.Log("Game Over");
    }

    public void Remove(int amount)
    {
        StartCoroutine(RemoveSmooth(amount));
    }

    public void Divide(int amount)
    {
        int a = transform.childCount / amount;
        int b = transform.childCount - a;
        StartCoroutine(RemoveSmooth(b));
    }

    public void Multiply(int amount)
    {
        int a = transform.childCount * (amount -1);
        StartCoroutine(AddSmooth(a));
    }

    public void Refresh()
    {
        amount = transform.childCount;

        if (amount > 0)
        {
            Dictionary<int, int> a = GetCircleCount();
            int totalMoved = 0;
            for (int i = 1; i <= a.Count; i++)
            {
                int b = a[i];
                float currentAngle = 0;
                float angle = (float)360 / a[i];
                for (int k = 0; k < b; k++)
                {
                    if (totalMoved + 1 > amount) break;

                    GameObject gameObject = transform.GetChild((transform.childCount - 1) - totalMoved).gameObject;
                    if (gameObject.tag == "MainCamera")
                    {
                        b++;
                        break;
                    }
                    if ((int)transform.forward.z != 0)
                    {
                        gameObject.transform.position = transform.position + new Vector3((space.x * i) * Mathf.Cos(ConvertToRadians(currentAngle + transform.rotation.z)), (space.y * i) * Mathf.Sin(ConvertToRadians(currentAngle)), 0);
                    }
                    else
                    {
                        gameObject.transform.position = transform.position + new Vector3(0, (space.y * i) * Mathf.Sin(ConvertToRadians(currentAngle)), (space.x * i) * Mathf.Cos(ConvertToRadians(currentAngle + transform.rotation.x)));
                    }
                    gameObject.SetActive(true);
                    gameObject.transform.forward = transform.forward;
                    currentAngle += angle;
                    totalMoved++;
                }
            }
        }
    }



    private float ConvertToRadians(float angle)
    {
        return (float)((Math.PI / 180) * angle);
    }

    private Dictionary<int, int> GetCircleCount()
    {
        int b = transform.childCount;
        int c = startAmount;
        Dictionary<int, int> a = new Dictionary<int, int>();
        int i = 1;
        do
        {
            if (b - c > 0)
            {
                a.Add(i, startAmount * i);
                b -= c;
                i++;
            }
            else
            {
                a.Add(i, b);
                b = 0;
            }
        } while (b > 0);
        return a;
    }
}
