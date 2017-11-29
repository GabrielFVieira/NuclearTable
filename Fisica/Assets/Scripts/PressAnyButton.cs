using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyButton : MonoBehaviour {
	public Texture2D cursor;
	public Texture2D cursor2;
	public Vector2 cursorHotspot;

    public GameObject[] panels;
	void Start () {
        panels[0].SetActive(true);
        panels[1].SetActive(false);
		Cursor.visible = true;
		cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
		Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
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

        if (Input.anyKeyDown)
        {
            if (panels[1].activeSelf == true)
                SceneManager.LoadScene("Main");

            else
            {
                panels[1].SetActive(true);
                panels[0].SetActive(false);
            }
        }
	}
}
