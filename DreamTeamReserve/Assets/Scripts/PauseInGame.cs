using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lol
{
    public class PauseInGame : MonoBehaviour
    {
        public bool isPaused;
        public Texture2D img_cross;
        void Start()
        {

        }


        void Update()
        {
            if (isPaused)
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
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