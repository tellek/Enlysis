using UnityEngine;
using System.Collections;

public class RotateWithMouse : MonoBehaviour
{
    //public float speed;
    public float speed = 2.0f;
    //public float speedV = 2.0f;
    public bool xAxis = true;
    public bool yAxis = false;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private float rotX = 0;
    //private float rotY = 0;

    private bool hasTarget = false;
    private bool wasStopped = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Cursor.visible = false;
        hasTarget = gameObject.GetComponent<FindTarget>().haveTarget;
    }

    void FixedUpdate()
    {
        if (hasTarget)
        {
            wasStopped = true;
            return;
        }
        //else if (wasStopped)
        //{
        //    print("rotX was " + rotX);

        //    Vector3 tempV;
        //    float tempF1;
        //    float tempF2;
        //    transform.rotation.ToAngleAxis(out tempF1, out tempV);
        //    transform.localRotation.ToAngleAxis(out tempF2, out tempV);
        //    var temp1 = Quaternion.Euler(0, tempF1, 0).y;
        //    var temp2 = Quaternion.Euler(0, tempF2, 0).y;

        //    print("tempF1=" + tempF1 + " - " + temp1 + " - " + temp2);
        //    rotX = tempF1;
        //    wasStopped = false;
        //}
        //else
        //{
        //    rotX += Input.GetAxis("Mouse X") * speed;
        //    //rotY += Input.GetAxis("Mouse Y") * speed;

        //    //transform.rotation = Quaternion.Euler(0, rotX, 0);
        //    transform.eulerAngles = new Vector3(0, rotX, 0);
        //}

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (xAxis) transform.Rotate(Vector3.up, mouseInput.x * speed);
        if (yAxis) transform.Rotate(Vector3.up, mouseInput.y * speed);

        //Plane playerPlane = new Plane(Vector3.up, transform.position);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //float hitdist = 0.0f;
        //if (playerPlane.Raycast(ray, out hitdist))
        //{
        //    Vector3 targetPoint = ray.GetPoint(hitdist);
        //    Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        //}






    }
}