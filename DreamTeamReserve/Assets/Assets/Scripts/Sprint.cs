using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lol
{
    public class Sprint : MonoBehaviour
    {
        public Slider EnergySlider;
        public GameObject Slider;

        public Player_Controller Player;

        private bool Vosstanovlenie;
        private bool CanRun = true;
        private bool Otdishka = false;

        private float Energy = 100;
        public float SkorostVichitania = 0.001f;
        public float SkorostPribavlenia = 0.01f;

        public AudioSource Player2;
        public AudioClip SighSound;
        public AudioClip RunSound;
        
        void Start() 
        {
            Slider.SetActive(false);
        }


        void Update()
        {
            EnergySlider.value = Energy;

            if (Input.GetKey(KeyCode.LeftShift) && Energy > 0 && CanRun)
            {
                Player.speed = 10;
                Slider.SetActive(true);
                Energy -= SkorostVichitania;
                Vosstanovlenie = false;
                Player2.clip = RunSound;
                Player2.Play();
                Player2.loop = true;
            }

            else
            {
                Player.speed = 5;
                if (Energy < 100 && Vosstanovlenie == true)
                {
                    Energy += SkorostPribavlenia;
                }
            }

            if(Energy < 100 && Vosstanovlenie == false && Input.GetKeyUp(KeyCode.LeftShift))
            {
                Player2.loop = false;
                Player2.Stop();
                StartCoroutine("WaitSomeSeconds");
            }



            if (Energy < 10 && Input.GetKeyUp(KeyCode.LeftShift) && Otdishka == false)
            {
                Player2.Stop();
                CanRun = false;
                Player2.clip = SighSound;
                Player2.Play();
                StartCoroutine("Oddishka");
                Otdishka = true;
            }
        }

        IEnumerator Oddishka()
        {
            yield return new WaitForSeconds(10);
            Player2.Stop();
            CanRun = true;
            Otdishka = false;
        }

        IEnumerator WaitSomeSeconds()
        {
            yield return new WaitForSeconds(2);

            Vosstanovlenie = true;
        }
    }
}