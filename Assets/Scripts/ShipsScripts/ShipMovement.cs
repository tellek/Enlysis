using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    public float moveSpeed = 2.5f;
    public float rotateSpeed = 150.0f;
    public float boostMultiplier = 2.0f;

    private bool isMoving = false;
    private float actualMoveSpeed = 0;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * actualMoveSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown("w"))
        {
            actualMoveSpeed = moveSpeed;
            isMoving = true;
        }

        if (Input.GetKeyUp("w"))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            if (Input.GetKey("left shift"))
            {
                actualMoveSpeed = moveSpeed * boostMultiplier;
            }
            else actualMoveSpeed = moveSpeed;
        }
    }
}
