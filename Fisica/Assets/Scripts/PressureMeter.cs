using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureMeter : MonoBehaviour {
	public bool active;
	public float timer;
	public float vel;

	public Manager manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Manager").GetComponent<Manager>();
		vel = -115;
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.restart == true) 
		{
			timer = 0;
			active = false;
		}

		if (active == true) 
		{
			transform.Rotate(0, 0, vel * Time.deltaTime);

			timer += Time.deltaTime;

			if (timer > 0.83f) 
			{
				active = false;
				timer = 0;
			}
		}
	}
}
