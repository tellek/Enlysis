using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{

    public float moveSpeed = 2.5f;
    public float rotateSpeed = 150.0f;
    public float boostMultiplier = 2.0f;
    public float reverseSpeed = 1.0f;
    public float strafeSpeed = 2.0f;

    private bool isMovingFoward = false;
    private bool isStrafing = false;
    private float actualMoveSpeed = 0;
    private float horizontalAxis = 0;
    private float verticalAxis = 0;

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        // Rotation.   
        if (!isStrafing)
        {
            var x = horizontalAxis * Time.deltaTime * rotateSpeed;
            transform.Rotate(0, x, 0);
        }
        
        // Forward/Backward thrust.
        var z = verticalAxis * Time.deltaTime * actualMoveSpeed;
        transform.Translate(0, 0, z);

        // Begin forward thrust.
        if (Input.GetKeyDown("w"))
        {
            isStrafing = false;
            actualMoveSpeed = moveSpeed;
            isMovingFoward = true;
        }
        // End forward thrust.
        if (Input.GetKeyUp("w"))
        {
            isMovingFoward = false;
            actualMoveSpeed = 0;
        }

        // Begin reverse thrust.
        if (Input.GetKeyDown("s"))
        {
            actualMoveSpeed = reverseSpeed;
        }
        // End reverse thrust.
        if (Input.GetKeyUp("s"))
        {
            actualMoveSpeed = moveSpeed;
        }

        if (isMovingFoward)
        {
            if (Input.GetKey("left shift"))
            {
                actualMoveSpeed = moveSpeed * boostMultiplier;
            }
            else actualMoveSpeed = moveSpeed;
        }

        if (Input.GetKey("left shift") && !isMovingFoward)
        {
            isStrafing = true;
            var strafe = horizontalAxis * Time.deltaTime * strafeSpeed;
            transform.Translate(strafe, 0, 0);
        }
        if (Input.GetKeyUp("left shift"))
        {
            isStrafing = false;
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 15, Screen.width, Screen.height), "Speed: " + actualMoveSpeed.ToString() + " (h:" + horizontalAxis.ToString() 
            + ")(v:" + verticalAxis.ToString() + ")");
    }
}
