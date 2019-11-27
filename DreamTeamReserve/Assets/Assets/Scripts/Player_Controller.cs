using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lol
{
    public class Player_Controller : MonoBehaviour
    {


        public G_U_I GUI_Script;

        private bool _flashlight;

        public GameObject Player_Cameras;
        // Переменные под мышь
        private float x_Rot;
        private float y_Rot;

        public float Sensa = 5f;
        public float smoothT = 0.1f;

        private float XRotation;
        private float YRotation;

        private float xRotVelocity;
        private float yRotVelocity;
        // Переменные пок клавиатуру
        public float speed = 10f;
        public float gravity = -10f;

        public float _jump_pow = 10f;
        private float _jump = 0;


        private CharacterController _Ch;



        /* // =========

        public Slider EnergySlider;
        public GameObject Slider;
        public GameObject PlayerObject;

        public Player_Controller Player;

        private bool Vosstanovlenie;
        private bool CanRun = true;
        private bool Otdishka = false;
        private bool SlowstepsSoundOn = false;

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

        // ========= */



        void Start()
        {
            _Ch = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;


            //Slider.SetActive(false);
        }

        void Update()
        {

            // Управление камерой(мышь)
            x_Rot -= Input.GetAxis("Mouse Y") * Sensa;
            y_Rot += Input.GetAxis("Mouse X") * Sensa;

            x_Rot = Mathf.Clamp(x_Rot, -90, 90);

            XRotation = Mathf.SmoothDamp(XRotation, x_Rot, ref xRotVelocity, smoothT);
            YRotation = Mathf.SmoothDamp(YRotation, y_Rot, ref yRotVelocity, smoothT);

            Player_Cameras.transform.rotation = Quaternion.Euler(XRotation, YRotation, 0);
            transform.rotation = Quaternion.Euler(0, YRotation, 0);
            // ------------------------------------------------------------------------------------

            // Управление персонажем (клава)
            float x_Mov = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float z_Mov = Input.GetAxis("Vertical") * speed * Time.deltaTime;

            if (_Ch.isGrounded)
            {
                _jump = 0;
                if (Input.GetKeyDown(KeyCode.Space)) //&& Energy >= 10)
                {
                    _jump = _jump_pow;
                    //Energy -= 10;
                }
            }
            _jump += gravity * Time.deltaTime * 3;

            Vector3 move = new Vector3(x_Mov, _jump * Time.deltaTime, z_Mov);
            move = Vector3.ClampMagnitude(move, speed);

            move = transform.TransformDirection(move);
            _Ch.Move(move);
            //---------------------------------------------------------------------------------------







            /*EnergySlider.value = Energy;

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

            if(Energy < 100)
            {
                Slider.SetActive(true);
            }

                if (Energy >= 99)
                {
                    Slider.SetActive(false);
                }

                if (Energy < 100 && Vosstanovlenie == false && Input.GetKeyUp(KeyCode.LeftShift))
                {
                    StartCoroutine("WaitSomeSeconds");
                }



                if (Energy < 10 && Input.GetKeyUp(KeyCode.LeftShift) && Otdishka == false)
                {
                    CanRun = false;
                    StartCoroutine("Oddishka");
                    Otdishka = true;
                }

            if (isRun == false && Input.GetKey(KeyCode.LeftControl))
            {
                isCrawling = true;
                Player.speed = 1.5f;
                SlowstepsSoundOn = true;
            }
                else if (isRun == false && Input.GetKeyUp(KeyCode.LeftControl))
                {
                    isCrawling = false;
                    Player.speed = 5f;
                SlowstepsSoundOn = false;
                
                }

            if (SlowstepsSoundOn)
            {
                StartCoroutine("SlowSt");

            }
            else if(SlowstepsSoundOn == false)
            {
                Audio.Stop();
            }

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) && isRun == false)
                {
                    isWalk = true;
                    isStay = false;
                }
                else if(isRun == true)
                {
                    isWalk = false;
                    isStay = false;
                }
            else
            {
                isWalk = false;
                isStay = true;
            }*/
            

            

        }

        /*IEnumerator Oddishka()
        {
            yield return new WaitForSeconds(6);
            CanRun = true;
            Otdishka = false;
        }

        IEnumerator WaitSomeSeconds()
        {
            yield return new WaitForSeconds(2);

            Vosstanovlenie = true;
        }*/
    }
}
