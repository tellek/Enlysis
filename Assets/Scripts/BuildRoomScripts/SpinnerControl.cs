using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerControl : MonoBehaviour {

    public GameObject PlayerObject;
    public GameObject Spinner;
    public float SpinSpeed = 30;
    public GameObject[] Cores;
    public GameObject[] Engines;
    public GameObject[] Thrusters;

    private bool shouldStart = true;

    private GameObject core;
    private int coreNum = 0;
    private GameObject engine;
    private int engNum = 0;
    private GameObject leftThruster;
    private int ltNum = 0;
    private GameObject rightThruster;
    private int rtNum = 0;

	void Start () {

    }
	
	void Update () {
        if (!shouldStart && !GlobalVariables.BuildRoomIsActive)
        {
            Vector3 pos = Vector3.zero;
            Quaternion rot = Quaternion.identity;

            foreach (Transform child in PlayerObject.transform)
            {
                pos = child.position;
                rot = child.rotation;
                Destroy(child.gameObject);
            }

            Instantiate(core, pos, rot, PlayerObject.transform);

            // Build room deactivated.
            shouldStart = true;
            DestroyAllParts();
        }
        if (!GlobalVariables.BuildRoomIsActive) return;
        if (shouldStart) StartProcess();

        transform.Rotate((Vector3.up * Time.deltaTime) * SpinSpeed);

        if (Input.GetKeyDown("1"))
        {
            if (coreNum >= Cores.Length - 1) coreNum = 0;
            else coreNum++;
            SetNewCore();
        }
        if (Input.GetKeyDown("2"))
        {
            SetPart(ref engine, Engines, ref engNum, "Engine");
        }
        if (Input.GetKeyDown("3"))
        {
            SetPart(ref leftThruster, Thrusters, ref ltNum, "LeftThruster");
        }
        if (Input.GetKeyDown("4"))
        {
            SetPart(ref rightThruster, Thrusters, ref rtNum, "RightThruster");
        }
    }

    private void SetPart(ref GameObject part, GameObject[] theList, ref int theCount, string partName)
    {
        if (theCount >= theList.Length - 1) theCount = 0;
        else theCount++;
        var pos = part.transform.position;
        var rot = part.transform.rotation;
        Destroy(part);
        part = theList[theCount];
        var mount = core.transform.Find(partName);
        part = Instantiate(part, pos, rot, mount);
    }

    private void StartProcess()
    {
        shouldStart = false;
        core = Cores[0];
        engine = Engines[0];
        leftThruster = Thrusters[0];
        rightThruster = Thrusters[0];

        core = Instantiate(core, transform.position, Quaternion.identity, transform);

        var engineMount = core.transform.Find("Engine");
        engine = Instantiate(engine, engineMount.transform.position, engine.transform.rotation, engineMount);

        var ltMount = core.transform.Find("LeftThruster");
        leftThruster = Instantiate(leftThruster, ltMount.transform.position, leftThruster.transform.rotation, ltMount);

        var rtMount = core.transform.Find("RightThruster");
        rightThruster = Instantiate(rightThruster, rtMount.transform.position, rightThruster.transform.rotation, rtMount);
    }

    private void SetNewCore()
    {
        var pos = core.transform.position;
        var rot = core.transform.rotation;
        var engPos = engine.transform.position;
        var engRot = engine.transform.rotation;
        var ltPos = leftThruster.transform.position;
        var ltRot = leftThruster.transform.rotation;
        var rtPos = rightThruster.transform.position;
        var rtRot = rightThruster.transform.rotation;
        Destroy(core);

        core = Cores[coreNum];
        engine = Engines[engNum];
        leftThruster = Thrusters[ltNum];
        rightThruster = Thrusters[rtNum];

        core = Instantiate(core, pos, rot, transform);

        var engineMount = core.transform.Find("Engine");
        engine = Instantiate(engine, engPos, engRot, engineMount);

        var ltMount = core.transform.Find("LeftThruster");
        leftThruster = Instantiate(leftThruster, ltPos, ltRot, ltMount);

        var rtMount = core.transform.Find("RightThruster");
        rightThruster = Instantiate(rightThruster, rtPos, rtRot, rtMount);
    }

    private void DestroyAllParts()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

}
