using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    public float speed = 0.1F;
    public Transform target;
    Camera camera;


    void Start()
    {


        camera = GetComponent<Camera>();
    }
    void Update()
    {

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        //    transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
        //}



        Vector3 screenPos = camera.WorldToScreenPoint(target.position);

        Vector3 proportion = new Vector3((float)screenPos.x / (float)Screen.width, (float)screenPos.y / (float)Screen.height, 0);

        Debug.Log(screenPos + " [" + Screen.width + ", " + Screen.height + "] " + proportion);
    }
}
