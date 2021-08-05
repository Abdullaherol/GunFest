using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [HideInInspector]
    public Vector2 Swipe = new Vector2();
    [Range(0,1)]
    public float sensitivity = .001f;
    public bool control;
    [HideInInspector]
    public GameObject target; // control obj
    private Vector3 lastPos;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            lastPos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            Swipe = (Input.mousePosition - lastPos) * sensitivity;
        }

        if (control)
        {

        }
    }
}
[CustomEditor(typeof(SwipeController))]
public class SwipeControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SwipeController swipeController= (SwipeController)target;

        if (swipeController.control)
            target = EditorGUILayout.ObjectField(swipeController.target,typeof(GameObject),true);
    }
}
