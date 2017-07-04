using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed { get; set; }
    public float DashSpeed { get; set; }
    public float DashTime { get; set; }

    private float _fixedUpdateTime;
    private float _dashTimeout;
    private bool _canMove;

    // Use this for initialization
    void Start()
    {
        _fixedUpdateTime = 0.125f;

        StartCoroutine(MoveToPosition(Vector2.down));
        StartCoroutine(Dash(Vector2.down));

    }

    public IEnumerator MoveToPosition(Vector2 position)
    {
        while (_canMove && position != new Vector2(transform.position.x, transform.position.y))
        {
            transform.Translate(position * Speed);
            yield return new WaitForSeconds(_fixedUpdateTime);
        }
    }

    public void Collect(GameObject item)
    {
        IEnumerator<int> iem;

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
