using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    // Use this for initialization
    void Start()
    {
        _controller = GetComponentInParent<CharacterController>();
    }

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {

        if (_controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,/* Input.GetAxis("Vertical")*/0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y,/* Input.GetAxis("Vertical")*/0);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);
    }

}
