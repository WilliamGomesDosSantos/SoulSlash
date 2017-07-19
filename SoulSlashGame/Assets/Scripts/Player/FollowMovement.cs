using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    public Transform Target;
    public bool CanMove;
    public bool IsMoving { get; set; }
    public float smoothTime = 3F;
    private Vector3 velocity = Vector3.zero;

    void Start () 
    {
        CanMove = true;
    }
    
    void Update () 
    {
        if (Target == null || !CanMove)
            return;
        Vector3 targetPosition = Target.TransformPoint(Vector3.zero);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        IsMoving = velocity.magnitude > 1;
    }
}
