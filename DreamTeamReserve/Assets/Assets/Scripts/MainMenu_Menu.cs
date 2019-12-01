using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lol
{
    public class MainMenu_Menu : MonoBehaviour
    {
        public AllOptionsPreferences PermanentOptionsPreferences;
        public GameObject ObjectOptionsPreferences;

        public GameObject MainMenuPanel;
        public GameObject OthersPanel;
        public GameObject OptionsPanel;
        public GameObject GamePanel;
        public GameObject GraphicPanel;
        public GameObject AudioPanel;
        public GameObject Black;

        void Start()
        {

        }


        void Update()
        {

        }

        public void StartGame()
        {
            
            
        }

        public void BackButton()
        {
            OptionsPanel.SetActive(false);
            Black.SetActive(false);
            MainMenuPanel.SetActive(true);
            OthersPanel.SetActive(false);
        }

        public void OptionsButton()
        {
            MainMenuPanel.SetActive(false);
            OptionsPanel.SetActive(true);
            OthersPanel.SetActive(true);
            Black.SetActive(true);
        }

        public void Game()
        {
            GamePanel.SetActive(true);
            GraphicPanel.SetActive(false);
            AudioPanel.SetActive(false);
            Black.SetActive(false);
        }
        public void Graphic()
        {
            GamePanel.SetActive(false);
            GraphicPanel.SetActive(true);
            AudioPanel.SetActive(false);
            Black.SetActive(false);
        }
        public void Audio()
        {
            GamePanel.SetActive(false);
            GraphicPanel.SetActive(false);
            AudioPanel.SetActive(true);
            Black.SetActive(false);
        }
    }
}