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
        void Start()
        {
            Controller = Player.GetComponent<Player_Controller>();
        }


        void Update()
        {
            if (isPaused)
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Controller.enabled = false;
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Controller.enabled = true;
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