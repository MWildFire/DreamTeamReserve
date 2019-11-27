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
        public GameObject PlayerObject;

        public Player_Controller Player;

        private bool Vosstanovlenie;
        private bool CanRun = true;
        private bool Otdishka = false;

        public bool isRun = false;
        public bool isWalk = false;
        public bool isCrawling = false;
        public bool isStay = true;

        private float Energy = 100;
        public float SkorostVichitania = 0.001f;
        public float SkorostPribavlenia = 0.01f;

        public AudioSource Audio;
        public AudioClip WalkingSound;
        public AudioClip RunningSound;
        public AudioClip SlowstepsSound;
        
        void Start() 
        {
            Slider.SetActive(false);
        }


        void Update()
        {
            EnergySlider.value = Energy;

            if (Input.GetKey(KeyCode.LeftShift) && Energy > 0 && CanRun && isStay != false)
            {
                Player.speed = 10;
                Slider.SetActive(true);
                Energy -= SkorostVichitania;
                Vosstanovlenie = false;
                isRun = true;
            }

            

            else
            {
                Player.speed = 5;
                if (Energy < 100 && Vosstanovlenie == true)
                {
                    Energy += SkorostPribavlenia;
                }
                isRun = false;
            }

            if(Energy >= 99)
            {
                Slider.SetActive(false);
            }

            if(Energy < 100 && Vosstanovlenie == false && Input.GetKeyUp(KeyCode.LeftShift))
            {
                StartCoroutine("WaitSomeSeconds");
            }



            if (Energy < 10 && Input.GetKeyUp(KeyCode.LeftShift) && Otdishka == false)
            {
                CanRun = false;
                StartCoroutine("Oddishka");
                Otdishka = true;
            }

            if(isRun == false && Input.GetKey(KeyCode.LeftControl))
            {
                isCrawling = true;
                Player.speed = 1.5f;
            }
            else if(isRun == false && Input.GetKeyUp(KeyCode.LeftControl))
            {
                isCrawling = false;
                Player.speed = 5f;
            }



            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                isWalk = false;
                isStay = true;
            }
            else
            {
                isWalk = true;
                isStay = false;
            }
        }

        IEnumerator Oddishka()
        {
            yield return new WaitForSeconds(6);
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