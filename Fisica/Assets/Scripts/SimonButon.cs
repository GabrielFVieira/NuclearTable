using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonButon : MonoBehaviour {
    public bool active;
    public bool active2;
    public Sprite[] states;
    public bool inteactable;

    public float timer;

    public Manager manager;
    // Use this for initialization
    void Start () {
        inteactable = true;
        active = false;
        GetComponent<SpriteRenderer>().sprite = states[0];
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (active == true)
        {
            GetComponent<SpriteRenderer>().sprite = states[1];
            timer += Time.deltaTime;
        }

        else if (active == false)
        {
            GetComponent<SpriteRenderer>().sprite = states[0];
        }

        if (timer > 0.5f)
        {
            active = false;
            timer = 0;
        }

        if (active2 == true)
            active2 = false;
    }

    private void OnMouseDown()
    {
        if(inteactable)
        {
            if (active == false && manager.numpad == "U235")
            {
                active = true;
                active2 = true;
            }

            if (active == false && manager.numpad != "U235" && timer == 0)
            {
                timer += Time.deltaTime;

                active = true;
                manager.errors += 1;

                if (manager.errors <= 5)
                    manager.meters2[0].active = true;
                else if (manager.errors > 5 && manager.errors <= 10)
                    manager.meters2[1].active = true;
                else if (manager.errors > 10 && manager.errors <= 15)
                    manager.meters2[2].active = true;

                if (timer >= 0.8f)
                    timer = 0;
            }
        }
    }
}
