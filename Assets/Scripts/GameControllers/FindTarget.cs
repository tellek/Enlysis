using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour {

    public float TargetRange = 150.0f;

    private Dictionary<int, GameObject> results = new Dictionary<int, GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("t"))
        {
            GameObject[] allResults = GameObject.FindGameObjectsWithTag("Enemy");
            if (allResults.Length <= 0)
            {
                print("No enemies found.");
            }
            else print(allResults.Length + " enemies found.");

            results.Clear();
            foreach (var ar in allResults)
            {
                int id = ar.GetInstanceID();

                if (Vector3.Distance(transform.position, ar.transform.position) <= TargetRange)
                {
                    results.Add(id, ar);
                }
            }
            if (results.Count <= 0)
            {
                print("No targets found.");
            }
            else print(results.Count + " targets found.");

            
        }
	}
}

// Get list of in range.
// Target closest.

// Once something is targeted:
// Get next GameObject in list