using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon : MonoBehaviour {
    public SimonButon[] buttons;
    public int state;
    public Manager manager;
    public float timer;
    public float timer2;
    public int correct;

    public GameObject senhaTxt;
    public GameObject genesisTxt;
    public GameObject winTxt;
    public GameObject errouTxt;

    public GameObject restartTxt;

    public bool startTimer;

    public float[] pos;
    public int[] posPicked;
    public int random;
    public int teste = 0;

    public float pX;
    public float pY;
    // Use this for initialization
    void Start () {
        genesisTxt.SetActive(false);
        winTxt.SetActive(false);
        correct = 1;
        manager = GameObject.Find("Manager").GetComponent<Manager>();
	}

    private void FixedUpdate()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            random = Random.Range(0, buttons.Length);

            if (posPicked[random] == 0)
            {
                pos[random] = teste;
                teste += 1;
                posPicked[random] = 1;
            }

            if (pos[i] == 0 || pos[i] == 2)
                pX = 0.16f;

            else if (pos[i] == 1 || pos[i] == 3)
                pX = 0.54f;

            if (pos[i] == 0 || pos[i] == 1)
                pY = 1.51f;

            else if (pos[i] == 2 || pos[i] == 3)
                pY = 1.2f;

            buttons[i].transform.localPosition = new Vector3(pX, pY, 0);
        }
    }

    // Update is called once per frame
    void Update () {
        if (manager.restart)
        {
            state = 0;
            correct = 1;
            timer = 0;
            timer2 = 0;
            genesisTxt.SetActive(false);
            winTxt.SetActive(false);
            errouTxt.SetActive(false);
            restartTxt.SetActive(false);

            foreach (SimonButon go in buttons)
            {
                go.active = false;
                go.active2 = false;
                go.timer = 0;
            }
       }

		if (manager.gif.activeSelf == true || manager.winTxt.activeSelf == true) 
		{
			foreach (SimonButon go in buttons) 
			{
				go.gameObject.GetComponent<SpriteRenderer> ().sprite = go.states [0];
				go.gameObject.GetComponent<AudioSource> ().enabled = false;
				go.enabled = false;
			}
		}

		if (manager.numpad == "U235" && manager.gif.activeSelf == false)
        {
            timer2 += Time.deltaTime;

            if (timer2 > 0.3f)
            {
                if (state == 0)
                {
                    errouTxt.SetActive(false);
                    senhaTxt.SetActive(false);
                    genesisTxt.SetActive(true);

                    foreach (SimonButon go in buttons)
                    {
                        go.inteactable = false;
                    }

                    if (timer == 0)
                        buttons[0].active = true;

                    timer += Time.deltaTime;

                    if (timer >= 0.5f)
                    {
                        if (timer >= 0.5f && timer <= 0.6f)
                            buttons[3].active = true;

                        if (timer >= 1f)
                        {
                            timer = 0;
                            state = 1;
                        }
                    }
                }

                if (state == 1)
                {
                    foreach (SimonButon go in buttons)
                    {
                        go.inteactable = true;
                    }

                    if (buttons[0].active == true && correct == 1)
                    {
                        buttons[0].active2 = false;
                        correct = 2;
                    }

                    if (buttons[3].active == true && correct == 2)
                    {
                        buttons[3].active2 = false;
                        state = 2;
                    }


                    if (buttons[0].active2 == true && correct != 1 && buttons[0].timer == 0 || buttons[1].active2 == true && correct != 3 && buttons[1].timer == 0 || buttons[2].active2 == true && correct != 4 && buttons[2].timer == 0 || buttons[3].active2 == true && correct != 2 && buttons[3].timer == 0)
                    {
                        startTimer = true;
                    }

                    if (startTimer)
                    {
                        timer += Time.deltaTime;

                        errouTxt.SetActive(true);

                        if (timer >= 0.4f)
                        {
                            state = 0;
                            correct = 1;
                            timer = 0;
                            startTimer = false;

                            manager.errors += 1;

                            if (manager.errors <= 3)
                                manager.meters2[0].active = true;
                            else if (manager.errors > 3 && manager.errors <= 6)
                                manager.meters2[1].active = true;
                            else if (manager.errors > 6 && manager.errors <= 9)
                                manager.meters2[2].active = true;
                        }
                    }
                }

                if (state == 2)
                {
                    correct = 1;

                    foreach (SimonButon go in buttons)
                    {
                        go.inteactable = false;
                    }

                    if (timer >= 0.8f && timer <= 0.9f)
                        buttons[0].active = true;

                    timer += Time.deltaTime;

                    if (timer >= 0.8f)
                    {
                        if (timer >= 1.3f && timer <= 1.4f)
                            buttons[3].active = true;

                        if (timer >= 1.3f)
                        {
                            if (timer >= 1.8f && timer <= 1.9f)
                                buttons[1].active = true;

                            if (timer >= 2.3f)
                            {
                                timer = 0;
                                state = 3;
                            }
                        }
                    }
                }

                if (state == 3)
                {
                    foreach (SimonButon go in buttons)
                    {
                        go.inteactable = true;
                    }

                    if (buttons[0].active == true && correct == 1)
                    {
                        buttons[0].active2 = false;
                        correct = 2;
                    }

                    if (buttons[3].active == true && correct == 2)
                    {
                        buttons[3].active2 = false;
                        correct = 3;
                    }

                    if (buttons[1].active == true && correct == 3)
                    {
                        buttons[1].active2 = false;
                        state = 4;
                    }

                    if (buttons[0].active2 == true && correct != 1 && buttons[0].timer == 0 || buttons[1].active2 == true && correct != 3 && buttons[1].timer == 0 || buttons[2].active2 == true && correct != 4 && buttons[2].timer == 0 || buttons[3].active2 == true && correct != 2 && buttons[3].timer == 0)
                    {
                        startTimer = true;
                    }

                    if (startTimer)
                    {
                        timer += Time.deltaTime;

                        errouTxt.SetActive(true);

                        if (timer >= 0.4f)
                        {
                            state = 0;
                            correct = 1;
                            timer = 0;
                            startTimer = false;

                            manager.errors += 1;

                            if (manager.errors <= 3)
                                manager.meters2[0].active = true;
                            else if (manager.errors > 3 && manager.errors <= 6)
                                manager.meters2[1].active = true;
                            else if (manager.errors > 6 && manager.errors <= 9)
                                manager.meters2[2].active = true;
                        }
                    }
                }

                if (state == 4)
                {
                    correct = 1;

                    foreach (SimonButon go in buttons)
                    {
                        go.inteactable = false;
                    }


                    if (timer >= 0.8f && timer <= 0.9f)
                        buttons[0].active = true;

                    timer += Time.deltaTime;

                    if (timer >= 0.8f)
                    {
                        if (timer >= 1.3f && timer <= 1.4f)
                            buttons[3].active = true;

                        if (timer >= 1.3f)
                        {
                            if (timer >= 1.8f && timer <= 1.9f)
                                buttons[1].active = true;

                            if (timer >= 2.3f && timer <= 2.4f)
                                buttons[2].active = true;

                            if (timer >= 2.8f)
                            {
                                timer = 0;
                                state = 5;
                            }
                        }
                    }
                }

                if (state == 5)
                {
                    foreach (SimonButon go in buttons)
                    {
                        go.inteactable = true;
                    }

                    if (buttons[0].active == true && correct == 1)
                    {
                        buttons[0].active2 = false;
                        correct = 2;
                    }

                    if (buttons[3].active == true && correct == 2)
                    {
                        buttons[3].active2 = false;
                        correct = 3;
                    }

                    if (buttons[1].active == true && correct == 3)
                    {
                        buttons[1].active2 = false;
                        correct = 4;
                    }

                    if (buttons[2].active == true && correct == 4)
                    {
                        buttons[2].active2 = false;
                        state = 6;

                        restartTxt.SetActive(true);

                        genesisTxt.SetActive(false);
                        winTxt.SetActive(true);
                        manager.desafio[1] = true;
                    }

                    if (buttons[0].active2 == true && correct != 1 && buttons[0].timer == 0 || buttons[1].active2 == true && correct != 3 && buttons[1].timer == 0 || buttons[2].active2 == true && correct != 4 && buttons[2].timer == 0 || buttons[3].active2 == true && correct != 2 && buttons[3].timer == 0)
                    {
                        startTimer = true;
                    }

                    if (startTimer)
                    {
                        timer += Time.deltaTime;

                        errouTxt.SetActive(true);

                        if (timer >= 0.4f)
                        {
                            state = 0;
                            correct = 1;
                            timer = 0;
                            startTimer = false;

                            manager.errors += 1;

                            if (manager.errors <= 3)
                                manager.meters2[0].active = true;
                            else if (manager.errors > 3 && manager.errors <= 6)
                                manager.meters2[1].active = true;
                            else if (manager.errors > 6 && manager.errors <= 9)
                                manager.meters2[2].active = true;
                        }
                    }
                }
            }
        }
	}
}
