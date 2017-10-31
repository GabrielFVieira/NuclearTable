using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {
	public Slider vol;
	public Sprite[] volume;
	public GameObject Sound;
    public Texture2D cursor;
    public Texture2D cursor2;
    public Vector2 cursorHotspot;
        // Use this for initialization
    void Start ()
    {
	    vol.value = AudioListener.volume;

        cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
        Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
    }

	public void FixedUpdate()
	{
		AudioListener.volume = vol.value;
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursor2, cursorHotspot, CursorMode.Auto);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
        }

        if (AudioListener.volume >= 0.7f)
		{
			Sound.GetComponent<Image>().sprite = volume[0];
		}

		if (AudioListener.volume >= 0.3f && AudioListener.volume < 0.7f)
		{
			Sound.GetComponent<Image>().sprite = volume[1];
		}

		if(AudioListener.volume > 0 && AudioListener.volume < 0.3f)
		{
			Sound.GetComponent<Image>().sprite = volume[2];
		}

		if (AudioListener.volume == 0)
		{
			Sound.GetComponent<Image>().sprite = volume[3];
		}

	}

	public void Credits()
	{
		
	}

	public void Back()
	{
		SceneManager.LoadScene("MainMenu");
	}

}
