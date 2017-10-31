using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton : MonoBehaviour
{
    public Sprite active;
    public Sprite desactive;

    public bool Actived;
    public bool interactable;

    public Manager manager;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        interactable = true;
        GetComponent<SpriteRenderer>().sprite = desactive;
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.restart == true)
        {
            interactable = true;
            GetComponent<SpriteRenderer>().sprite = desactive;
            Actived = false;
        }

        if (GetComponent<SpriteRenderer>().sprite == desactive)
        {
            Actived = false;
        }

        else
            Actived = true;

		if (GameObject.Find("Door").GetComponent<TableDoor>().open != 0 || manager.numpad == "U235")
        {
            interactable = false;
            GetComponent<SpriteRenderer>().sprite = desactive;
            Actived = false;
        }
    }

    private void OnMouseDown()
    {
		if (interactable && manager.Led.GetComponent<Animator> ().enabled == false)
        {
            if (GetComponent<SpriteRenderer>().sprite == desactive)
            {
                GetComponent<SpriteRenderer>().sprite = active;
            }

            else
                GetComponent<SpriteRenderer>().sprite = desactive;
        }
    }
}
