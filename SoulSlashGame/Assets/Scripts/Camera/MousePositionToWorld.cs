using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionToWorld : MonoBehaviour 
{
    public bool IsUpdating;
    public Vector3 Position;



    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            Position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

}
