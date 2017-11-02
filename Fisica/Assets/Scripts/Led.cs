using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Led : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Animator> ().enabled == true && GetComponent<AudioSource> ().isPlaying == false)
			GetComponent<AudioSource> ().Play ();
	}
}
