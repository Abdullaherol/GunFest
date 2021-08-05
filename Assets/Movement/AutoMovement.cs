using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    private SwipeController swipeController;

    public Vector2 borderMax;
    public Vector2 borderMin;
    public LayerMask layer;
    public float speed;
    public float rotationSpeed;
    public float distance = 1;

    private Transform lastHit;
    private Vector3 targetRotation;
    void Start()
    {
        swipeController = GetComponent<SwipeController>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 swipe = swipeController.Swipe;

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.up * -1, Color.red);
        if (Physics.Raycast(transform.position, transform.up * -1, out hit, 20, layer))
        {
            Debug.DrawLine(transform.position, hit.point);
            if (lastHit == null)
                lastHit = hit.transform;
            else
            {
                if (lastHit != hit.transform)
                {
                    //pos = new Vector3();

                    Vector3 direction = hit.transform.forward * -1;

                    targetRotation = hit.transform.eulerAngles;

                    transform.eulerAngles = targetRotation;

                    lastHit = hit.transform;
                }
            }
            if (hit.transform.tag == "Part")
            {
                if ((int)hit.transform.forward.z != 0)
                {
                    float a = swipe.x;
                    if (a > hit.transform.position.x + (hit.transform.localScale.x / borderMax.x))
                        a = hit.transform.position.x + (hit.transform.localScale.x / borderMax.x);
                    if (a < hit.transform.position.x + (hit.transform.localScale.x / borderMin.x))
                        a = hit.transform.position.x + (hit.transform.localScale.x / borderMin.x);

                    transform.position = Vector3.Lerp(transform.position, new Vector3(a, transform.position.y, transform.position.z + (distance * hit.transform.forward.z * -1)), speed * Time.deltaTime);

                }
                else
                {
                    float a = swipe.x;
                    if (a > hit.transform.position.z + (hit.transform.localScale.x / borderMax.y))
                        a = hit.transform.position.z + (hit.transform.localScale.x / borderMax.y);
                    if (a < hit.transform.position.z + (hit.transform.localScale.x / borderMin.y))
                        a = hit.transform.position.z + (hit.transform.localScale.x / borderMin.y);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + (distance * hit.transform.forward.x * -1), transform.position.y, a), speed * Time.deltaTime);
                }
            }

            //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, speedRotation* Time.deltaTime);   
        }
        else
        {
            if ((int)lastHit.transform.forward.z != 0)
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + (distance * lastHit.transform.forward.z * -1)), speed * Time.deltaTime);
            else transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + (distance * lastHit.transform.forward.x * -1), transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
}
