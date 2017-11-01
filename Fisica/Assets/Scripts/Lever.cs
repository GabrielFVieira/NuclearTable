using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
    public float timer;
    public Manager manager;

    public Sprite up;

    public GameObject resetText;
    // Use this for initialization
    void Start () {
        resetText.SetActive(false);
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        GetComponent<Animator>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Animator>().enabled == true)
            timer += Time.deltaTime;

        if(timer >= 0.65f)
        {
            resetText.SetActive(false);
            manager.restart = true;
            timer = 0;
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = up;
        }
	}

    private void OnMouseDown()
    {
        if (manager.Led.GetComponent<Animator>().enabled == false)
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
