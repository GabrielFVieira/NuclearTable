using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour {
    public PanelButton[] botões1;
    public PanelButton[] botões2;
    public PanelButton[] botões3;
    public PanelButton[] botões4;
    public PanelButton[] botões5;
    public PanelButton[] botões6;
    public PanelButton[] botões7;

    public bool[] correct;

    public GameObject numTxt;
    public GameObject questionTxt;
    public GameObject littleBoy;

    public Manager manager;
    // Use this for initialization
    void Start () {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        numTxt = GameObject.Find("PasswordText");
        //questionTxt = GameObject.Find("QuestionText");
    }
	
	// Update is called once per frame
	void Update () {
        if(manager.restart == true)
        {
            numTxt.SetActive(true);
            questionTxt.SetActive(false);
            littleBoy.SetActive(false);

            correct[0] = correct[1] = correct[2] = correct[3] = correct[4] = correct[5] = correct[6] = false;
            foreach (PanelButton pb in botões1)
            {
                pb.interactable = true;
            }

            foreach (PanelButton pb in botões2)
            {
                pb.interactable = true;
            }

            foreach (PanelButton pb in botões3)
            {
                pb.interactable = true;
            }

            foreach (PanelButton pb in botões4)
            {
                pb.interactable = true;
            }

            foreach (PanelButton pb in botões5)
            {
                pb.interactable = true;
            }

            foreach (PanelButton pb in botões6)
            {
                pb.interactable = true;
            }

            foreach (PanelButton pb in botões7)
            {
                pb.interactable = true;
            }
        }

        if (correct[0] && correct[1] && correct[2] && correct[3] && correct[4] && correct[5] && correct[6] && littleBoy.activeSelf == false)
        {
            numTxt.SetActive(false);
            questionTxt.SetActive(true);
            foreach(PanelButton pb in botões1)
            {
                pb.interactable = false;
            }

            foreach (PanelButton pb in botões2)
            {
                pb.interactable = false;
            }

            foreach (PanelButton pb in botões3)
            {
                pb.interactable = false;
            }

            foreach (PanelButton pb in botões4)
            {
                pb.interactable = false;
            }

            foreach (PanelButton pb in botões5)
            {
                pb.interactable = false;
            }

            foreach (PanelButton pb in botões6)
            {
                pb.interactable = false;
            }

            foreach (PanelButton pb in botões7)
            {
                pb.interactable = false;
            }
        }

        //1
        if (botões1[0].Actived == false && botões1[1].Actived == false && botões1[2].Actived == false && botões1[3].Actived == true && botões1[4].Actived == false && botões1[5].Actived == false && botões1[6].Actived == false)
            correct[0] = true;

        else
            correct[0] = false;
        //2
		if (botões2[0].Actived == false && botões2[1].Actived == false && botões2[2].Actived == false && botões2[3].Actived == false && botões2[4].Actived == false && botões2[5].Actived == false && botões2[6].Actived == false)
            correct[1] = true;

        else
            correct[1] = false;
        //3
        if (botões3[0].Actived == true && botões3[1].Actived == false && botões3[2].Actived == false && botões3[3].Actived == false && botões3[4].Actived == false && botões3[5].Actived == false && botões3[6].Actived == true)
            correct[2] = true;

        else
            correct[2] = false;
        //4
        if (botões4[0].Actived == false && botões4[1].Actived == false && botões4[2].Actived == false && botões4[4].Actived == false && botões4[5].Actived == false && botões4[6].Actived == false && botões4[3].Actived == true)
            correct[3] = true;

        else
            correct[3] = false;
        //5
		if (botões5[0].Actived == false && botões5[1].Actived == false && botões5[2].Actived == false && botões5[3].Actived == false && botões5[4].Actived == false && botões5[5].Actived == false && botões5[6].Actived == false)
            correct[4] = true;

        else
            correct[4] = false;
        //6
		if (botões6[0].Actived == false && botões6[1].Actived == false && botões6[2].Actived == false && botões6[3].Actived == false && botões6[4].Actived == false && botões6[5].Actived == false && botões6[6].Actived == false)
            correct[5] = true;

        else
            correct[5] = false;
        //7
        if (botões7[0].Actived == false && botões7[1].Actived == true && botões7[2].Actived == false && botões7[3].Actived == false && botões7[4].Actived == false && botões7[5].Actived == true && botões7[6].Actived == false)
            correct[6] = true;

        else
            correct[6] = false;

    }
}
