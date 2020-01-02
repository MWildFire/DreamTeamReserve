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

        public GameObject OthersPanel;
        public GameObject OptionsPanel;
        public GameObject CreditsPanel;

        public Slider GeneralSounds;
        public Slider Music;
        public Slider Sounds;
        public Slider Other;

        public Toggle Mute;

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

            if (PlayerPrefs.HasKey("FullScreen"))
            {
                if(PlayerPrefs.GetInt("FullScreen") == 0)
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
                GeneralSounds.value = 50;
            }

            if (PlayerPrefs.HasKey("Music"))
            {
                Music.value = PlayerPrefs.GetFloat("Music");
            }
            else
            {
                Music.value = 50;
            }

            if (PlayerPrefs.HasKey("Sounds"))
            {
                Sounds.value = PlayerPrefs.GetFloat("Sounds");
            }
            else
            {
                Sounds.value = 50;
            }

            if (PlayerPrefs.HasKey("Other"))
            {
                Other.value = PlayerPrefs.GetFloat("Other");
            }
            else
            {
                Other.value = 50;
            }


            if (PlayerPrefs.HasKey("Mute"))
            {
                if(PlayerPrefs.GetInt("Mute") == 0)
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

            // =============================================================================
        }

        //========================== Кнопки ==========================

        public void Play()
        {
            SceneManager.LoadSceneAsync(2);
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
            if(Screen.fullScreen == true)
            {
                PlayerPrefs.SetInt("FullScreen", 1);
            }
            else
            {
                PlayerPrefs.SetInt("FullScreen", 0);
            }
        }

        

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
            if(Mute.isOn == true)
            {
                PlayerPrefs.SetInt("Mute", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Mute", 0);
            }
            
        }

        //============================================================
    }
}