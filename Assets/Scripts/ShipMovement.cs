using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotateSpeed = 150.0f;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
