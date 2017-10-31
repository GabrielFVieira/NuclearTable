using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetText : MonoBehaviour {
    public float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer > 0.3f)
        {
            GetComponent<Text>().enabled = !GetComponent<Text>().enabled;
            timer = 0;
        }

    }
}
