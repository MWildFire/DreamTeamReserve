using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace lol
{
    public class PauseMenu : MonoBehaviour
    {
        public PauseInGame GeneralPauseScript;
        private bool isOpen;
        public GameObject PausePanel;
        public GameObject OptionsPanel;
        void Start()
        {
            PausePanel.SetActive(false);
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isOpen == false && GeneralPauseScript.isPaused == false)
            {
                GeneralPauseScript.isPaused = true;
                PausePanel.SetActive(true);
                isOpen = true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isOpen == true && GeneralPauseScript.isPaused == true)
            {
                GeneralPauseScript.isPaused = false;
                PausePanel.SetActive(false);
                isOpen = false;
            }
        }

        // ========================== Кнопки =============================

        public void ContinueButton()
        {
            GeneralPauseScript.isPaused = false;
            PausePanel.SetActive(false);
            isOpen = false;
        }

        public void RestartButton()
        {
            SceneManager.LoadSceneAsync(2);
        }

        public void OptionsButton()
        {
            OptionsPanel.SetActive(true);
        }

        public void BackToMenu()
        {
            OptionsPanel.SetActive(false);
        }

        public void BackToMainMenu()
        {
            SceneManager.LoadSceneAsync(1);
        }

        public void BackToScreen()
        {
            Application.Quit();
        }

        // ===============================================================
    }
}