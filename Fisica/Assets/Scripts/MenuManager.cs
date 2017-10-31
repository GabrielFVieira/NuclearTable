using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public Texture2D cursor;
    public Texture2D cursor2;
    public Vector2 cursorHotspot;
    // Use this for initialization
    void Start () {
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
    }

	public void PlayGame()
	{
		SceneManager.LoadScene ("Instructions");
	}

	public void Options()
	{
		SceneManager.LoadScene ("Options");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}
