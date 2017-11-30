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

		//Debug.Log (wrench.gameObject.transform.eulerAngles);
	}

	public void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Wrench") {
			timer += Time.deltaTime;

			wrench.GetComponent<AudioSource> ().Play ();


			if (wrench.gameObject.transform.eulerAngles.z > 1)
				wrench.gameObject.transform.Rotate (0, 0, 60 * Time.deltaTime);
			else
				wrench.gameObject.transform.eulerAngles = new Vector3 (0, 0, 315);

			if (timer > 1) {
				wrench.gameObject.transform.eulerAngles = new Vector3 (0, 0, 315);
				manager.fix += 1;
				gameObject.SetActive (false);
				timer = 0;
			}
		}
	}

	public void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Wrench") {
			timer = 0;
			wrench.GetComponent<AudioSource> ().Stop ();
			wrench.gameObject.transform.eulerAngles = new Vector3 (0, 0, 315);
		}
	}
}
