using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public float timer;
    public Manager manager;

    public Sprite[] states;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Wait());

        if (manager.restart == true)
        {
            GetComponent<Animator>().SetBool("Pressed", false);
            GetComponent<SpriteRenderer>().sprite = states[1];
            timer = 0;
        }

        if (GetComponent<Animator>().GetBool("Pressed") == true)
        {
            GetComponent<SpriteRenderer>().sprite = states[0];
            timer += Time.deltaTime;

            if (timer > 0.2f)
            {
                GetComponent<Animator>().SetBool("Pressed", false);
                GetComponent<SpriteRenderer>().sprite = states[1];
                timer = 0;
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        
    }

    private void OnMouseDown()
    {
		if (GetComponent<Animator>().GetBool("Pressed") == false && timer == 0 && manager.Led.GetComponent<Animator>().enabled == false && manager.winTxt.activeSelf == false)
        {
            GetComponent<Animator>().SetBool("Pressed", true);
            manager.controle = true;
            GetComponent<AudioSource>().Play();
        }

        else
            GetComponent<Animator>().SetBool("Pressed", false);
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sprite = states[1];
        timer = 0;
        GetComponent<Animator>().SetBool("Pressed", false);
    }
}
