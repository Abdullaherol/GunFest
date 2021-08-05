using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject target;
    public float speedRotation;

    void Update()
    {
        if(target != null)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, target.transform.eulerAngles + new Vector3(20,180,0), speedRotation * Time.deltaTime);
        }
        
    }
}
