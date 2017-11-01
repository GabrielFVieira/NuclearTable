using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
	public Sprite[] states;
	public bool active;
	public Manager manager;

	public GameObject passwordTxt;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find("Manager").GetComponent<Manager>();
		GetComponent<SpriteRenderer> ().sprite = states [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.restart == true) 
		{
			GetComponent<SpriteRenderer> ().sprite = states [0];
			active = false;
		}
	}

	private void OnMouseDown()
	{
		if (manager.numpad != "2003" && manager.numpad != "U235" && passwordTxt.activeSelf == true && manager.Led.GetComponent<Animator>().enabled == false) {
			if (GetComponent<SpriteRenderer> ().sprite == states [0]) {
				active = true;
				GetComponent<SpriteRenderer> ().sprite = states [1];
			} else {
				active = false;
				GetComponent<SpriteRenderer> ().sprite = states [0];
			}
            GetComponent<AudioSource>().Play();
        }
	}
}
