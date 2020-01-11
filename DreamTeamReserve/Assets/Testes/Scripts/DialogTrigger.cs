using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public KeyCode ButtonForInteractive;
    public bool inZone = false;
    public Player_Controller Controller;

    /*public void TriggerDialog()
    {
        if (Input.GetKeyDown(ButtonForInteractive))
        {
            if (inZone == true)
            {
                FindObjectOfType<DialogManager>().StartDialog(dialog);
            }
        }
    }*/

    void Update()
    {
        if (Input.GetKeyDown(ButtonForInteractive))
        {
            if (inZone == true)
            {
                FindObjectOfType<DialogManager>().StartDialog(dialog);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Controller.enabled = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inZone = false;
        }
    }
}
