using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace lol
{
    public class MainMenu_UI : MonoBehaviour
    {
        // Скрипт отвечающий за настройки \/
        public GameObject AllOptionsObject;
        public AllOptionsPreferences GeneralOptionsScript;
        // Скрипт отвечающий за настройки /\

        public GameObject OthersPanel;
        public GameObject OptionsPanel;
        public GameObject CreditsPanel;

        void Start()
        {
            OthersPanel.SetActive(false);
            OptionsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
        }


        void Update()
        {

        }

        //========================== Кнопки ==========================

        public void Play()
        {
            SceneManager.LoadSceneAsync(3);
            Scene nextScene = SceneManager.GetSceneAt(3);
            SceneManager.MoveGameObjectToScene(AllOptionsObject, nextScene);
        }

        public void Options()
        {
            OthersPanel.SetActive(true);
            OptionsPanel.SetActive(true);
        }

        public void Credits()
        {
            OthersPanel.SetActive(true);
            CreditsPanel.SetActive(true);
        }

        public void BackToMenu()
        {
            OthersPanel.SetActive(false);
            OptionsPanel.SetActive(false);
            CreditsPanel.SetActive(false);
        }

        public void Exit()
        {
            Application.Quit();
        }

        //============================================================
    }
}