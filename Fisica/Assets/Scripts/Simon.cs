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
    // Use this for initialization
    void Start () {
        genesisTxt.SetActive(false);
        winTxt.SetActive(false);
        correct = 1;
        manager = GameObject.Find("Manager").GetComponent<Manager>();
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

        if (manager.numpad == "U235")
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

                            if (manager.errors <= 5)
                                manager.meters2[0].active = true;
                            else if (manager.errors > 5 && manager.errors <= 10)
                                manager.meters2[1].active = true;
                            else if (manager.errors > 10 && manager.errors <= 15)
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

                            if (manager.errors <= 5)
                                manager.meters2[0].active = true;
                            else if (manager.errors > 5 && manager.errors <= 10)
                                manager.meters2[1].active = true;
                            else if (manager.errors > 10 && manager.errors <= 15)
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

                            if (manager.errors <= 5)
                                manager.meters2[0].active = true;
                            else if (manager.errors > 5 && manager.errors <= 10)
                                manager.meters2[1].active = true;
                            else if (manager.errors > 10 && manager.errors <= 15)
                                manager.meters2[2].active = true;
                        }
                    }
                }
            }
        }
	}
}
