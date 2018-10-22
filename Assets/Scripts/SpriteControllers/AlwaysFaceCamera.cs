using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFaceCamera : MonoBehaviour {

    public Camera CameraToFace;

    void Update () {
        if (CameraToFace == null) transform.LookAt(Camera.main.transform);
        else transform.LookAt(CameraToFace.transform);
    }
}
