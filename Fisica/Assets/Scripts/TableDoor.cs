using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDoor : MonoBehaviour {
    public int open;
    public float timer1;
    public float timer2;

    public Sprite closed;

    public GameObject uranium;
    public float vel = 0.7f;
    public bool down;

    public Manager manager;

	public Animator toolGate;

    public GameObject resetText;

	public GameObject uranio;
	public GameObject fixTxt;

    public GameObject close;
    // Use this for initialization
    void Start () {
		uranio.SetActive (false);
        resetText.SetActive(false);
        uranium.SetActive(false);
        manager = GameObject.Find("Manager").GetComponent<Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (manager.Led.GetComponent<Animator> ().enabled == false) {
			if (manager.restart == true) {
				uranio.SetActive (false);
				timer1 = timer2 = 0;
				GetComponent<SpriteRenderer> ().sprite = closed;
				GetComponent<Animator> ().SetInteger ("Open", 0);
				open = 0;
				manager.numpad = "";
				manager.down = false;
				manager.tableDoorOpen = 0;
				uranium.transform.position = new Vector3 (transform.position.x, -4.15f, transform.position.z);
				uranium.SetActive (false);
			}

			open = manager.tableDoorOpen;

			toolGate.SetInteger ("States", open);

			GetComponent<Animator> ().SetInteger ("Open", open);

			if (open == 1) {
				timer1 += Time.deltaTime;
                GetComponent<AudioSource>().Play();
			}

			if (open == 3) {
				timer2 += Time.deltaTime;
                close.GetComponent<AudioSource>().Play();
                GetComponent<AudioSource>().Play();
            }

			if (timer1 >= 0.2f) {
				manager.tableDoorOpen = 2;
				timer1 = 0;
			}

			if (timer2 >= 0.2f) {
				manager.tableDoorOpen = 4;
				timer2 = 0;
			}

			if (manager.tableDoorOpen == 2 && manager.down == false) {
				uranium.SetActive (true);
                if (uranium.transform.position.y < -0.58f)
                {
                    uranium.transform.Translate(0, vel * Time.deltaTime, 0);
                    uranium.GetComponent<AudioSource>().enabled = true;
                }

                if (uranium.transform.position.y > -0.58f)
                    uranium.GetComponent<AudioSource>().enabled = false;
            }

			if (manager.down == true) {


                if (uranium.transform.position.y > -4.02f)
                {
                    uranium.transform.Translate(0, -vel * Time.deltaTime, 0);
                    uranium.GetComponent<AudioSource>().enabled = true;
                }
                else
                {
                    uranium.GetComponent<AudioSource>().enabled = false;
                    fixTxt.SetActive(false);
                    uranio.SetActive(true);
                    manager.desafio[2] = true;
                    resetText.SetActive(true);
                    manager.tableDoorOpen = 3;
                }
			}
		}
	}
}
