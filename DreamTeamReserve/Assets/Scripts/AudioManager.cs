using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lol
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource[] GeneralAudio_sources;
        public AudioSource[] Sounds_sources;
        public AudioSource[] Music_sources;
        public AudioSource[] Other_sources;

        void Start()
        {
            
        }


        void Update()
        {
            for (int i = 0; i < GeneralAudio_sources.Length; i++)
            {
                if (PlayerPrefs.HasKey("GeneralAudio"))
                {
                    GeneralAudio_sources[i].volume = PlayerPrefs.GetFloat("GeneralAudio");
                }
                else
                {
                    GeneralAudio_sources[i].volume = 0.5f;
                }
                
                if (PlayerPrefs.HasKey("Mute"))
                {
                    if (PlayerPrefs.GetInt("Mute") == 0)
                    {
                        GeneralAudio_sources[i].mute = false;
                    }
                    else
                    {
                        GeneralAudio_sources[i].mute = true;
                    }
                }
                else
                {
                    GeneralAudio_sources[i].mute = false;
                }
            }

            for (int i = 0; i < Sounds_sources.Length; i++)
            {
                if (PlayerPrefs.HasKey("Sounds"))
                {
                    Sounds_sources[i].volume = PlayerPrefs.GetFloat("Sounds");
                }
                else
                {
                    Sounds_sources[i].volume = 0.5f;
                }

                if (PlayerPrefs.HasKey("Mute"))
                {
                    if (PlayerPrefs.GetInt("Mute") == 0)
                    {
                        GeneralAudio_sources[i].mute = false;
                    }
                    else
                    {
                        GeneralAudio_sources[i].mute = true;
                    }
                }
                else
                {
                    GeneralAudio_sources[i].mute = false;
                }
            }

            for (int i = 0; i < Music_sources.Length; i++)
            {
                if (PlayerPrefs.HasKey("Music"))
                {
                    Music_sources[i].volume = PlayerPrefs.GetFloat("Music");
                }
                else
                {
                    Music_sources[i].volume = 0.5f;
                }

                if (PlayerPrefs.HasKey("Mute"))
                {
                    if (PlayerPrefs.GetInt("Mute") == 0)
                    {
                        GeneralAudio_sources[i].mute = false;
                    }
                    else
                    {
                        GeneralAudio_sources[i].mute = true;
                    }
                }
                else
                {
                    GeneralAudio_sources[i].mute = false;
                }
            }

            for (int i = 0; i < Other_sources.Length; i++)
            {
                if (PlayerPrefs.HasKey("Other"))
                {
                    Other_sources[i].volume = PlayerPrefs.GetFloat("Other");
                }
                else
                {
                    Other_sources[i].volume = 0.5f;
                }

                if (PlayerPrefs.HasKey("Mute"))
                {
                    if (PlayerPrefs.GetInt("Mute") == 0)
                    {
                        GeneralAudio_sources[i].mute = false;
                    }
                    else
                    {
                        GeneralAudio_sources[i].mute = true;
                    }
                }
                else
                {
                    GeneralAudio_sources[i].mute = false;
                }
            }


        }
    }
}