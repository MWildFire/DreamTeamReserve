using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lol
{
    public class PauseInGame : MonoBehaviour
    {
        public GameObject Player;
        private Player_Controller Controller;
        [HideInInspector]
        public bool isPaused;
        public Texture2D img_cross;
        public GameObject GreyPanel;
        public GameObject[] HideObjects;
        void Start()
        {
            Controller = Player.GetComponent<Player_Controller>();
            GreyPanel.SetActive(false);
        }


        void Update()
        {
            if (isPaused)
            {
                DisplayUI();
            }
            else
            {
                DisplayUI();
            }
        }

        public void DisplayUI()
        {
            if (isPaused)
            {
                Time.timeScale = 1f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Controller.enabled = false;
                GreyPanel.SetActive(true);
                for (int i = 0; i < HideObjects.Length; i++)
                {
                    HideObjects[i].SetActive(false);
                }
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Controller.enabled = true;
                GreyPanel.SetActive(false);
                for (int i = 0; i < HideObjects.Length; i++)
                {
                    HideObjects[i].SetActive(true);
                }
            }
        }

        private void OnGUI()
        {
            if (isPaused)
            {

            }
            else
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 15, 15), img_cross);
            }
        }
    }
}