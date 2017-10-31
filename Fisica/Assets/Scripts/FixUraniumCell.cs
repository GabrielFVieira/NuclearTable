using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixUraniumCell : MonoBehaviour {
	public Wrench wrench;
	public float timer;
	public Manager manager;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Manager").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.fix >= 4) 
		{
			gameObject.SetActive (false);
		}
	}

	public void OnTriggerStay2D(Collider2D col)
	{
		timer += Time.deltaTime;

		if (timer > 1) 
		{
			manager.fix += 1;
			gameObject.SetActive (false);
			timer = 0;
		}
	}

	public void OnTriggerExit2D(Collider2D col)
	{
		timer = 0;
	}
}
