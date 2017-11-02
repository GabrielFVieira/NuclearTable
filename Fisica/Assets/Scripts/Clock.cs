using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
    public float hours, minutes, seconds;

    public GameObject Led;
	// Use this for initialization
	void Start () {
        hours = System.DateTime.Now.Hour;
        minutes = 55;
        seconds = 0;
	}

    // Update is called once per frame
    void Update() {
        if(seconds >= 10 && minutes >= 10)
            GetComponent<Text>().text = hours + ":" + minutes + ":" + Mathf.FloorToInt(seconds);

        else if(minutes >=10 && seconds < 10)
            GetComponent<Text>().text = hours + ":" + minutes + ":0" + Mathf.FloorToInt(seconds);

        else if (minutes < 10 && seconds >= 10)
            GetComponent<Text>().text = hours + ":0" + minutes + ":" + Mathf.FloorToInt(seconds);

        else
            GetComponent<Text>().text = hours + ":0" + minutes + ":0" + Mathf.FloorToInt(seconds);

        seconds += Time.deltaTime;

		if(minutes == 59 && seconds > 60 && GameObject.Find("Manager").GetComponent<Manager>().winTxt.activeSelf == false)
		{
			Led.GetComponent<Animator>().enabled = true;
		}

        if (seconds >= 60)
        {
            minutes += 1;
            seconds = 0;
        }

        if (minutes >= 60)
        {
            hours += 1;
            minutes = 0;
        }
    }
}
