using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    public GameObject[] buttons;
    public float[] pos;
    public int[] posPicked;
    public int random;
    public int teste = 0;

    public float pX;
    public float pY;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
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

            if (pos[i] == 0 || pos[i] == 3 || pos[i] == 5)
                pX = 4.478697f;

            else if (pos[i] == 1 || pos[i] == 2 || pos[i] == 4)
                pX = 5.428697f;

            if (pos[i] == 0 || pos[i] == 1)
                pY = 0.2078625f;

            else if (pos[i] == 2 || pos[i] == 3)
                pY = -0.7f;

            else if (pos[i] == 4 || pos[i] == 5)
                pY = -1.6f;

            buttons[i].transform.localPosition = new Vector3(pX, pY, 0);
        }

    }
}