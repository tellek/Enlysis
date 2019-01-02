using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeRecieveDamage : MonoBehaviour {

	private GameObject text;
	private GameObject attacker;
	private int damageDealt = 0;

	// Use this for initialization
	void Start () {
		text = GameObject.Find("Text");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
    {
		attacker = collision.gameObject;
        var tm = text.GetComponent<TextMesh>();
		var dmg = Convert.ToInt32(attacker.GetComponent<ProjectileController>().EndDamageAmount);
		damageDealt += dmg;
		tm.text = "Damage: " + damageDealt + " (+" + dmg + ")";
    }
}
