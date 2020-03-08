using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace lol
{
    public class PauseMenu : MonoBehaviour
    {
        public PauseInGame GeneralPauseScript;
        private bool isOpen;
        public GameObject PausePanel;
        public GameObject OptionsPanel;


        //========================= Настройки =========================

        public Slider GeneralSounds;
        public Slider Music;
        public Slider Sounds;
        public Slider Other;

        public Dropdown ResolutionDropdown;
        Resolution[] res;

        public Toggle Fullscreen;
        public Toggle Mute;

        public Dropdown QualitySettinsDropdown;

        //=============================================================

        void Start()
        {
            PausePanel.SetActive(false);
            OptionsPanel.SetActive(false);

            //================================= Resolution =================================

            if (PlayerPrefs.HasKey("FullScreen"))
            {
                if (PlayerPrefs.GetInt("FullScreen") == 0)
                {
                    Screen.fullScreen = false;
                    Fullscreen.isOn = Screen.fullScreen;
                }
                else
                {
                    Screen.fullScreen = true;
                    Fullscreen.isOn = Screen.fullScreen;
                }
            }
            else
            {
                Screen.fullScreen = true;
                Fullscreen.isOn = Screen.fullScreen;
            }

            Resolution[] resolution = Screen.resolutions;
            res = resolution.Distinct().ToArray();
            string[] strRes = new string[resolution.Length];
            for (int i = 0; i < res.Length; i++)
            {
                strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
            }
            ResolutionDropdown.ClearOptions();
            ResolutionDropdown.AddOptions(strRes.ToList());
            if (PlayerPrefs.HasKey("Resolution"))
            {
                ResolutionDropdown.value = PlayerPrefs.GetInt("Resolution");
                Screen.SetResolution(res[PlayerPrefs.GetInt("Resolution")].width, res[PlayerPrefs.GetInt("Resolution")].height, Screen.fullScreen);
            }
            else
            {
                Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
                ResolutionDropdown.value = res.Length - 1;
            }


            //==============================================================================



            //================================== Quality ===================================

            QualitySettinsDropdown.ClearOptions();
            QualitySettinsDropdown.AddOptions(QualitySettings.names.ToList());
            if (PlayerPrefs.HasKey("Quality"))
            {
                QualitySettinsDropdown.value = PlayerPrefs.GetInt("Quality");
                QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
            }
            else
            {
                QualitySettinsDropdown.value = QualitySettings.GetQualityLevel();
            }

            //==============================================================================



            // =================================== Audio ===================================

            if (PlayerPrefs.HasKey("GeneralAudio"))
            {
                GeneralSounds.value = PlayerPrefs.GetFloat("GeneralAudio");
            }
            else
            {
                GeneralSounds.value = 0.5f;
            }

            if (PlayerPrefs.HasKey("Music"))
            {
                Music.value = PlayerPrefs.GetFloat("Music");
            }
            else
            {
                Music.value = 0.5f;
            }

            if (PlayerPrefs.HasKey("Sounds"))
            {
                Sounds.value = PlayerPrefs.GetFloat("Sounds");
            }
            else
            {
                Sounds.value = 0.5f;
            }

            if (PlayerPrefs.HasKey("Other"))
            {
                Other.value = PlayerPrefs.GetFloat("Other");
            }
            else
            {
                Other.value = 0.5f;
            }


            if (PlayerPrefs.HasKey("Mute"))
            {
                if (PlayerPrefs.GetInt("Mute") == 0)
                {
                    Mute.isOn = false;
                }
                else
                {
                    Mute.isOn = true;
                }
            }
            else
            {
                Mute.isOn = false;
            }
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

        public void SetRes()
        {
            Screen.SetResolution(res[ResolutionDropdown.value].width, res[ResolutionDropdown.value].height, Screen.fullScreen);
            PlayerPrefs.SetInt("Resolution", ResolutionDropdown.value);
        }

        public void SetQuality()
        {
            QualitySettings.SetQualityLevel(QualitySettinsDropdown.value);
            PlayerPrefs.SetInt("Quality", QualitySettinsDropdown.value);
        }

        public void ScreenMode()
        {
            Screen.fullScreen = Fullscreen.isOn;
            if (Screen.fullScreen == true)
            {
                PlayerPrefs.SetInt("FullScreen", 1);
            }
            else
            {
                PlayerPrefs.SetInt("FullScreen", 0);
            }
        }




        public void ContinueButton()
        {
            GeneralPauseScript.isPaused = false;
            PausePanel.SetActive(false);
            isOpen = false;
        }

        public void RestartButton()
        {
            SceneManager.LoadSceneAsync(1);
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
            SceneManager.LoadSceneAsync(0);
        }

        public void BackToScreen()
        {
            Application.Quit();
        }

        // ===============================================================



        // ====================== Настройки ==============================

        public void SetGeneralSounds()
        {
            PlayerPrefs.SetFloat("GeneralAudio", GeneralSounds.value);
        }

        public void SetMusic()
        {
            PlayerPrefs.SetFloat("Music", Music.value);
        }

        public void SetSounds()
        {
            PlayerPrefs.SetFloat("Sounds", Sounds.value);
        }

        public void SetOther()
        {
            PlayerPrefs.SetFloat("Other", Other.value);
        }

        public void SetMute()
        {
            if (Mute.isOn == true)
            {
                PlayerPrefs.SetInt("Mute", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Mute", 0);
            }

        }

        // ===============================================================
    }
}