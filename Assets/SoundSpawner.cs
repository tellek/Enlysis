using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSpawner : MonoBehaviour {
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
		sound.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (!sound.isPlaying) {
			Destroy(gameObject);
		}
	}
}
