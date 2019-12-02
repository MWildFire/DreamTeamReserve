using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lol
{
    public class Player_Controller : MonoBehaviour
    {
        // Переменные под спринт
        public Slider Slider_Sprint;
        private float Sprint = 100;


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



        void Start()
        {
            _Ch = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;



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

            Slider_Sprint.value = Sprint;
            if (_Ch.isGrounded)
            {
                // ----------------------- Проверка на приседание -------------------------------------
                RaycastHit Crouch;
                Debug.DrawRay(transform.position, transform.up * 1f, Color.red);
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    _Ch.height = 1;
                }
                
                else
                {
                    if (Physics.Raycast(transform.position, transform.up, out Crouch, 1f))
                    {
                        _Ch.height = 1;
                    }
                    else
                    {
                        _Ch.height = 2;
                    }
                }

                // ---------------------------------------- Спринт ------------------------------------

                
                if (Input.GetKey(KeyCode.LeftShift) && Sprint > 10 && (x_Mov != 0 || z_Mov != 0))
                {
                    speed = 15f;
                    Sprint -= 0.3f;
                    
                }
                else
                {
                    speed = 10f;
                    if (Sprint <= 100)
                    {
                        Sprint += 0.1f;
                    }
                    
                }

                // ------------------------------------------------------------------------------------
                _jump = 0;
                if (Input.GetKeyDown(KeyCode.Space) && Sprint > 5)
                {
                    _jump = _jump_pow;
                    Sprint -= 5f;
                }
            }
            _jump += gravity * Time.deltaTime * 3;

            Vector3 move = new Vector3(x_Mov, _jump * Time.deltaTime, z_Mov);
            move = Vector3.ClampMagnitude(move, speed);

            move = transform.TransformDirection(move);
            _Ch.Move(move);
            //---------------------------------------------------------------------------------------
        }

    }
}
