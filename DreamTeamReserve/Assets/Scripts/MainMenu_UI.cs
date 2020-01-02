using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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

        //========================= Настройки =========================

        public Dropdown ResolutionDropdown;
        Resolution[] res;

        public Toggle Fullscreen;

        public Dropdown QualitySettinsDropdown;

        //=============================================================



        void Start()
        {
            OthersPanel.SetActive(false);
            OptionsPanel.SetActive(false);
            CreditsPanel.SetActive(false);

            //================================= Resolution =================================

            Screen.fullScreen = true;

            Resolution[] resolution = Screen.resolutions;
            res = resolution.Distinct().ToArray();
            string[] strRes = new string[resolution.Length];
            for (int i = 0; i < res.Length; i++)
            {
                strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
            }
            ResolutionDropdown.ClearOptions();
            ResolutionDropdown.AddOptions(strRes.ToList());
            Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
            ResolutionDropdown.value = res.Length - 1;

            //==============================================================================



            //================================== Quality ===================================

            QualitySettinsDropdown.ClearOptions();
            QualitySettinsDropdown.AddOptions(QualitySettings.names.ToList());
            QualitySettinsDropdown.value = QualitySettings.GetQualityLevel();

            //==============================================================================
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



        //======================== Настройки =========================
        public void SetRes()
        {
            Screen.SetResolution(res[ResolutionDropdown.value].width, res[ResolutionDropdown.value].height, Screen.fullScreen);
        }

        public void SetQuality()
        {
            QualitySettings.SetQualityLevel(QualitySettinsDropdown.value);
        }

        public void ScreenMode()
        {
            Screen.fullScreen = Fullscreen.isOn;
        }

        //============================================================
    }
}