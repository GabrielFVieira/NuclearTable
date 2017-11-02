using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour {
	public Animator toolGate;
	public Vector3 startPos;
	public bool active;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		Vector2 pos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);

		if (toolGate.GetInteger("States") == 2) 
		{
			GetComponent<SpriteRenderer> ().sortingOrder = 10;
		}

		else
			GetComponent<SpriteRenderer> ().sortingOrder = 2;

		if (active == true) 
		{
			transform.position = pos;
		}

		if (active == false) 
		{
			transform.position = startPos;
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		Cursor.visible = !active;
		
	}

	private void OnMouseDown()
	{
		if (GetComponent<SpriteRenderer> ().sortingOrder == 10) 
		{
			active = !active;

			if(active)
				transform.eulerAngles = new Vector3 (0, 0, -45);
		}
	}
}
