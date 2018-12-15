using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBasedMovement : MonoBehaviour {

    public float forwardSpeed = 200f;
    public float reverseSpeed = 200f;
    public float strafeSpeed = 200f;
    public float boostMultiplier = 2.0f;
    public float thrustPower = 5.0f;
    public float forwardThrustMultiplier = 2.5f;

    private float horizontalAxis = 0;
    private float verticalAxis = 0;
    private Rigidbody rb;
    private bool hasTarget = false;
    private Vector3 currentVelocity = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        hasTarget = gameObject.GetComponent<FindTarget>().haveTarget;
        currentVelocity = rb.velocity;
    }

    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(-transform.right * thrustPower, ForceMode.Impulse);
                if (hasTarget)
                {
                    rb.AddForce(transform.forward * thrustPower * forwardThrustMultiplier, ForceMode.Impulse);
                }
            }
            else
            {
                rb.AddRelativeForce(horizontalAxis * strafeSpeed, 0, 0, ForceMode.Acceleration);
            }
        }

        if (Input.GetKey("d"))
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(transform.right * thrustPower, ForceMode.Impulse);
                if (hasTarget)
                {
                    rb.AddForce(transform.forward * thrustPower * forwardThrustMultiplier, ForceMode.Impulse);
                }
            }
            else
            {
                rb.AddRelativeForce(horizontalAxis * strafeSpeed, 0, 0, ForceMode.Acceleration);
            }
        }

        if (Input.GetKey("s"))
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(-transform.forward * thrustPower, ForceMode.Impulse);
            }
            else
            {
                rb.AddRelativeForce(0, 0, verticalAxis * reverseSpeed, ForceMode.Acceleration);
            }
        }

        if (Input.GetKey("w"))
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(transform.forward * thrustPower, ForceMode.Impulse);
            }
            else
            {
                if (Input.GetKey("left shift"))
                {
                    rb.AddRelativeForce(0, 0, (verticalAxis * forwardSpeed) * boostMultiplier, ForceMode.Acceleration);
                }
                else
                {
                    rb.AddRelativeForce(0, 0, verticalAxis * forwardSpeed, ForceMode.Acceleration);
                }
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 15, Screen.width, Screen.height), "Speed: " + currentVelocity.ToString() + " (h:" + horizontalAxis.ToString()
            + ")(v:" + verticalAxis.ToString() + ")");
    }
}
