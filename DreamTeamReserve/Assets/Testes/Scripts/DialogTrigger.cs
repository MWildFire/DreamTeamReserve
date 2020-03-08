using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public KeyCode ButtonForInteractive;
    public bool inZone;
    public Player_Controller Controller;
    public GameObject Hint;

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
            if (inZone == true && Controller.enabled == true)
            {
                FindObjectOfType<DialogManager>().StartDialog(dialog);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Controller.enabled = false;
            }
        }
        if (inZone)
        {
            Hint.SetActive(true);
        }
        else
        {
            Hint.SetActive(false);
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
