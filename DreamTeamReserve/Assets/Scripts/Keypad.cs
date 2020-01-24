using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lol
{
    public class Keypad : MonoBehaviour
    {
        public InputField PassField;
        public string Password;
        public GameObject KeypadPanel;
        [HideInInspector]
        public bool canOpen;
        public PauseInGame GeneralPauseObject;

        public void OpenPanel()
        {
            KeypadPanel.SetActive(true);
        }

        public void Confirm()
        {
            if (PassField.text == Password)
            {
                Cancel();
                canOpen = true;
            }
        }

        public void Cancel()
        {
            KeypadPanel.SetActive(false);
            PassField.text = "";
            GeneralPauseObject.isPaused = false;
        }

        public void Clear()
        {
            PassField.text = "";
        }
    }
}