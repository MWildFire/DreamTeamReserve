using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lol
{
    public class PauseMenu : MonoBehaviour
    {
        public PauseInGame GeneralPauseScript;
        private bool isOpen;
        public GameObject PausePanel;
        void Start()
        {

        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && isOpen == false && GeneralPauseScript.isPaused == false)
            {
                GeneralPauseScript.isPaused = true;
                PausePanel.SetActive(true);
                isOpen = true;
            }
            else if(Input.GetKeyDown(KeyCode.Tab) && isOpen == true && GeneralPauseScript.isPaused == true)
            {
                GeneralPauseScript.isPaused = false;
                PausePanel.SetActive(false);
                isOpen = false;
            }
        }
    }
}