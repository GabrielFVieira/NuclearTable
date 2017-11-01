using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPad : MonoBehaviour {
    public string senha;
    public string ano;


    public int charCount;
    public int charCount2;

    public float timer;
    public float timer2;

    public Text passwordText;
    public Text questionText;
	public Text fixTheCellTxt;
    public Image LittleBoy;

    public NumPadButtons[] nums;

    public string[] SenhasCertas;

    public Manager manager;

    public GameObject resetText;

	public PressureMeter[] meters;

	public Switch u235;
	// Use this for initialization
	void Start () {
        resetText.SetActive(false);
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        passwordText = GameObject.Find("PasswordText").GetComponent<Text>();
        //questionText = GameObject.Find("QuestionText").GetComponent<Text>();

        SenhasCertas[0] = "2 0 0 3 ";
		SenhasCertas[1] = "2 3 5 ";
    }
	
	// Update is called once per frame
	void Update () {
		if (manager.Led.GetComponent<Animator> ().enabled == false) {
			if (manager.restart == true) {
				senha = "";
				ano = "";
				timer = timer2 = charCount = charCount2 = 0;
				fixTheCellTxt.gameObject.SetActive (false);
			}

			//ANO
			if (charCount2 >= 4) {
				if (ano == "1 9 4 5 " && questionText.gameObject.activeSelf == true) {
					foreach (NumPadButtons num in nums) {
						num.Active = false;
					}

					timer2 += Time.deltaTime;
					manager.desafio [0] = true;
					resetText.SetActive (true);
					if (timer2 >= 0.5f) {
						questionText.gameObject.SetActive (false);
						LittleBoy.gameObject.SetActive (true);

						timer = 0;
					}
				} else {
					timer2 += Time.deltaTime;

					if (ano != "1 9 4 5 ") {
                        if (manager.errors < 3)
                            manager.meters2[0].active = true;
                        else if (manager.errors >= 3 && manager.errors < 6)
                            manager.meters2[1].active = true;
                        else if (manager.errors >= 6 && manager.errors < 9)
                            manager.meters2[2].active = true;
                    }
					if (timer2 >= 0.5f) {	
						if (ano != "1 9 4 5 ")
							manager.errors += 1;
					
						ano = "";
						charCount2 = 0;
						timer2 = 0;
					}
				}
			}

			if (charCount2 == 0)
				questionText.text = "A bomba atômica \n Little Boy foi \n lançada em: \n _ _ _ _ ";
			else if (charCount2 == 1)
				questionText.text = "A bomba atômica \n Little Boy foi \n lançada em: \n" + ano + "_ _ _ ";
			else if (charCount2 == 2)
				questionText.text = "A bomba atômica \n Little Boy foi \n lançada em: \n" + ano + "_ _ ";
			else if (charCount2 == 3)
				questionText.text = "A bomba atômica \n Little Boy foi \n lançada em: \n" + ano + "_ ";
			else if (charCount2 == 4)
				questionText.text = "A bomba atômica \n Little Boy foi \n lançada em: \n" + ano;


			//NÚMERO
			if (charCount >= 3 && u235.active == true) {
				if (senha == SenhasCertas [1]) {
					manager.numpad = "U235";
					foreach (NumPadButtons num in nums) {
						num.Active = false;
					}
				} else {
                    if (manager.errors < 3)
                        manager.meters2[0].active = true;
                    else if (manager.errors >= 3 && manager.errors < 6)
                        manager.meters2[1].active = true;
                    else if (manager.errors >= 6 && manager.errors < 9)
                        manager.meters2[2].active = true;

                    timer += Time.deltaTime;
					if (timer >= 0.5f) {
						manager.errors += 1;



						senha = "";
						charCount = 0;
						timer = 0;
					}
				}
			}

			if (u235.active == true) {
				if (charCount == 0)
					passwordText.text = "Senha: U _ _ _ ";
				else if (charCount == 1)
					passwordText.text = "Senha: U " + senha + "_ _ ";
				else if (charCount == 2)
					passwordText.text = "Senha: U " + senha + "_ ";
				else if (charCount == 3)
					passwordText.text = "Senha: U " + senha;
		
			}



			if (charCount >= 4 && u235.active == false) {
				if (senha == SenhasCertas [0]) {
					manager.numpad = "2003";
					timer += Time.deltaTime;
					foreach (NumPadButtons num in nums) {
						num.Active = false;
					}

					if (timer >= 0.5f) {
						passwordText.gameObject.SetActive (false);
						fixTheCellTxt.gameObject.SetActive (true);
						timer = 0;
						senha = "";
						charCount = 0;
					}
				} else {
                    if (manager.errors < 3)
                        manager.meters2[0].active = true;
                    else if (manager.errors >= 3 && manager.errors < 6)
                        manager.meters2[1].active = true;
                    else if (manager.errors >= 6 && manager.errors < 9)
                        manager.meters2[2].active = true;

                    timer += Time.deltaTime;
					if (timer >= 0.5f) {
						manager.errors += 1;


					
						senha = "";
						charCount = 0;
						timer = 0;
					}
				}

			}
			if (u235.active == false) {
				if (charCount == 0)
					passwordText.text = "Senha: _ _ _ _ ";
				else if (charCount == 1)
					passwordText.text = "Senha: " + senha + "_ _ _ ";
				else if (charCount == 2)
					passwordText.text = "Senha: " + senha + "_ _ ";
				else if (charCount == 3)
					passwordText.text = "Senha: " + senha + "_ ";
				else if (charCount == 4)
					passwordText.text = "Senha: " + senha;
			}
		}
	}
}
