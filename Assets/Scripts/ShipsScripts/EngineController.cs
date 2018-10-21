using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour {

    public float LowItensity = 1.4f;
    public float MediumItensity = 1.8f;
    public float HighItensity = 2.2f;

    private Renderer thisRenderer;
    private bool isMoving = false;

    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
    }

	void Update () {
        if (Input.GetKeyDown("w"))
        {
            thisRenderer.material.SetFloat("_Glow", MediumItensity); // Raises shader Intensity
            isMoving = true;
        }

        if (Input.GetKeyUp("w"))
        {
            thisRenderer.material.SetFloat("_Glow", LowItensity); // Lowers shader Intensity
            isMoving = false;
        }

        if (isMoving)
        {
            if (Input.GetKey("left shift"))
            {
                thisRenderer.material.SetFloat("_Glow", HighItensity); // Raises shader Intensity
            }
            else thisRenderer.material.SetFloat("_Glow", MediumItensity); // Raises shader Intensity
        }
	}
}
