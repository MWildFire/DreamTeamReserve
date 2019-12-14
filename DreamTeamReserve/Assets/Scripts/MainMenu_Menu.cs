using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace lol
{
    public class MainMenu_Menu : MonoBehaviour
    {
        public AllOptionsPreferences PermanentOptionsPreferences;
        public GameObject ObjectOptionsPreferences;

        private bool isOptions = false;
        private bool isCredits = false;
        private bool isMainMenu = true;
        private bool isGame = false;
        private bool isGraphic = false;
        private bool isAudio = false;

        public Texture2D BG;
        public Texture2D BLACK;
        public Texture2D BLACKwithRED;
        public Texture2D Mitya;
        public Texture2D Pocik;
        public Texture2D F1N;
        public Texture2D David;
        public Texture2D Ivan;
        public Texture2D Evgen;

        public GUIStyle Text;

        void Start()
        {

        }


        void Update()
        {

        }

        public void OnGUI()
        {
            if (isMainMenu)
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
                GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), BG);

                if (GUI.Button(new Rect(125, 300, 500, 100), "Начать"))
                {
                    SceneManager.LoadScene(1);
                }

                if (GUI.Button(new Rect(125, 425, 500, 100), "Настройки"))
                {
                    isOptions = true;
                    isMainMenu = false;
                }

                if (GUI.Button(new Rect(125, 550, 500, 100), "Авторы"))
                {
                    isCredits = true;
                    isMainMenu = false;
                }

                if (GUI.Button(new Rect(125, 675, 500, 100), "Выход из игры"))
                {
                    Application.Quit();
                }



                GUI.EndGroup();
            }

            // ----------------------- Настройки -----------------------

            if (isOptions)
            {
                GUI.Box(new Rect(0, 0, 5000, 5000), "");
                GUI.BeginGroup(new Rect(0, 0, 5000, 5000));
                GUI.Label(new Rect(0, 0, 5000, 5000), BLACK);

                if (GUI.Button(new Rect(10, 10, 200, 100), "Назад"))
                {
                    isOptions = false;
                    isGame = false;
                    isGraphic = false;
                    isAudio = false;
                    isMainMenu = true;
                }

                if (GUI.Button(new Rect(250, 10, 500, 100), "Игра"))
                {
                    isGame = true;
                    isGraphic = false;
                    isAudio = false;
                }

                if (GUI.Button(new Rect(800, 10, 500, 100), "Графика"))
                {
                    isGraphic = true;
                    isGame = false;
                    isAudio = false;
                }

                if (GUI.Button(new Rect(1350, 10, 500, 100), "Аудио"))
                {
                    isAudio = true;
                    isGame = false;
                    isGraphic = false;
                }

                GUI.EndGroup();
            }

            if (isGame)
            {
                GUI.Box(new Rect(0, 125, 5000, 5000), "");
                GUI.BeginGroup(new Rect(0, 125, 5000, 5000));
                GUI.Label(new Rect(0, 0, 5000, 5000), BLACKwithRED);

                GUI.EndGroup();
            }

            if (isGraphic)
            {
                GUI.Box(new Rect(0, 125, 5000, 5000), "");
                GUI.BeginGroup(new Rect(0, 125, 5000, 5000));
                GUI.Label(new Rect(0, 0, 5000, 5000), BLACKwithRED);

                GUI.EndGroup();
            }

            if (isAudio)
            {
                GUI.Box(new Rect(0, 125, 5000, 5000), "");
                GUI.BeginGroup(new Rect(0, 125, 5000, 5000));
                GUI.Label(new Rect(0, 0, 5000, 5000), BLACKwithRED);

                GUI.EndGroup();
            }

            // ---------------------------------------------------------



            // ------------------------- Авторы ------------------------
            if (isCredits)
            {

                GUI.Box(new Rect(0, 0, 5000, 5000), "");
                GUI.BeginGroup(new Rect(0, 0, 5000, 5000));
                GUI.Label(new Rect(0, 0, 5000, 5000), BLACK);

                if (GUI.Button(new Rect(10, 10, 150, 75), "Назад"))
                {
                    isCredits = false;
                    isMainMenu = true;
                }

                GUI.Label(new Rect(10, 125, 100, 50), "Босс, спонсор: Митя", Text);
                GUI.Label(new Rect(75, 180, 250, 250), Mitya);

                GUI.Label(new Rect(10, 450, 100, 50), "Скриптинг, моделинг: Поц", Text);
                GUI.Label(new Rect(75, 525, 250, 250), Pocik);

                GUI.Label(new Rect(500, 125, 100, 50), "Моделинг, работа в Unity: Фин", Text);
                GUI.Label(new Rect(625, 180, 250, 250), F1N);

                GUI.Label(new Rect(600, 450, 100, 50), "Моделинг: Давид", Text);
                GUI.Label(new Rect(625, 525, 250, 250), David);

                GUI.Label(new Rect(1125, 125, 100, 50), "Работа в Unity: Ваня", Text);
                GUI.Label(new Rect(1175, 180, 250, 250), Ivan);

                GUI.Label(new Rect(1125, 450, 100, 50), "Помощь из рая: Женя", Text);
                GUI.Label(new Rect(1175, 525, 250, 250), Evgen);

                GUI.EndGroup();
            }
            // ---------------------------------------------------------
        }
    }
}