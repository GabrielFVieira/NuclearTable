using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPadButtons : MonoBehaviour
{
    public int num;
    public Color col;
    public Color colInicial;

    public NumPad panel;
    public GameObject questionTxt;

    public bool Active;

    public Manager manager;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        Active = true;
        colInicial = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.restart == true)
        {
            Active = true;
            GetComponent<SpriteRenderer>().color = colInicial;
        }
    }

    private void OnMouseDown()
    {
		if (manager.Led.GetComponent<Animator> ().enabled == false  && manager.winTxt.activeSelf == false) {
			if (Active == true && questionTxt.activeSelf == false) {
				if (panel.charCount < 4) {
					panel.senha += num.ToString () + " ";
					panel.charCount++;
					GetComponent<SpriteRenderer> ().color = col;

                    GetComponent<AudioSource>().Play();
                }
			}

			if (Active == true && questionTxt.activeSelf == true  && manager.winTxt.activeSelf == false) {
				if (panel.charCount < 4) {
					panel.ano += num.ToString () + " ";
					panel.charCount2++;
					GetComponent<SpriteRenderer> ().color = col;

                    GetComponent<AudioSource>().Play();
                }
			}
		}
    }

    private void OnMouseUp()
    {
            GetComponent<SpriteRenderer>().color = colInicial;
    }
}
