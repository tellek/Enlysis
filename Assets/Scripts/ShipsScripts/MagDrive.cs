using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagDrive : MonoBehaviour {

	public float hoverHeight = 5f;
	public float hoverForce = 5f;

	private Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, hoverHeight)) {
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 actualForce = Vector3.up * proportionalHeight * hoverForce;
			rb.AddForce(actualForce, ForceMode.Acceleration);
		}
	}
}
