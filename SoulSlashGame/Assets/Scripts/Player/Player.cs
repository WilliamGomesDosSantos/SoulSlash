using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Player : MonoBehaviour
{

    public float Speed { get; set; }
    public float DashSpeed { get; set; }
    public float DashTime { get; set; }

    public Transform Target;

    private float _fixedUpdateTime;
    private float _dashTimeout;
    private bool _canMove;

    // Use this for initialization
    void Start()
    {
        _fixedUpdateTime = 0.125f;
        _canMove = true;
        Speed = 1;
        StartCoroutine(MoveToPosition());
    }


    private bool _moving;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    public IEnumerator MoveToPosition()
    {
        _moving = true;
        while (_canMove && (Target.position - this.transform.position).magnitude < 1)
        {

            yield return new WaitForSeconds(0.3f);
            //Vector3 newPosition = new Vector3(moveToPosition.x, moveToPosition.y, this.transform.position.z);
            // transform.position = Vector3.Lerp(transform.position, newPosition, Speed * Time.deltaTime*0.0001f);
            // transform.Translate(Vector3.Lerp(transform.position, newPosition, Speed * Time.deltaTime * 0.1f));

            //Vector3 targetPosition = Target.TransformPoint(new Vector3(0, 5, -10));
            // transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        _moving = false;
    }


    public void Collect(GameObject item)
    {

    }

    public IEnumerator Dash(Vector2 direction)
    {
        _canMove = false;
        _dashTimeout = DashTime;
        while (_dashTimeout >= 0)
        {
            transform.Translate(direction * DashSpeed);
            yield return new WaitForSeconds(_fixedUpdateTime);
            _dashTimeout -= _fixedUpdateTime;
        }
        _canMove = true;
    }

    public IEnumerator ThrowLantern()
    {
        yield break;
    }
}
