using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardTarget : MonoBehaviour {

    
    public GameObject target;

	void Start () {
		
	}
	
	void Update () {
        
        target = transform.parent.parent.parent.parent.GetComponent<FindTarget>().target;
        if (target == null) return;

        transform.LookAt(target.transform);

    }
}
