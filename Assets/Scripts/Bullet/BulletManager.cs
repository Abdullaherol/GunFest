using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public BulletPositionManager positionManager;
    public PartManager partManager;
    public GameObject prefab;
    public List<Bullet> bullets = new List<Bullet>();

    private int amount;

    private void Start()
    {
        amount = partManager.GetTotalRequireAmount();
        Spawn(amount);
    }
    
    private void Spawn(int a)
    {
        for (int i = 0; i < a; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(transform);

            Bullet bullet = obj.GetComponent<Bullet>();
            bullet.bulletManager = this;

            bullets.Add(bullet);
        }
    }

    public void Add(int count)
    {
        positionManager.Add(count);
    }
    public void Remove(int count)
    {
        positionManager.Remove(count);
    }
    
    public void Divide(int count)
    {
        positionManager.Divide(count);
    }

    public void Multiply(int count)
    {
        positionManager.Multiply(count);
    }
}