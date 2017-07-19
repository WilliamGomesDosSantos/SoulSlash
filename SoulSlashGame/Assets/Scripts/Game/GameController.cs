using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{

    public Camera MainCamera;
    public Transform PlayerPivot;

    private Vector3 zLock = new Vector3(1, 1, 0);

    private int? x;

    void Update () 
    {
        // controlling movement
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0)) 
        {
            PlayerPivot.position =(Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
#elif UNITY_ANDROID || UNITY_IPHONE || !UNITY_EDITOR
        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began) 
        {
            PlayerPivot.position =(Vector2) Camera.main.ScreenToWorldPoint(touch.position);
        }
#endif
    }
}
