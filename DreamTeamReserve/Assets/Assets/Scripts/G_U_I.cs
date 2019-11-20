using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lol
{
    public class G_U_I : MonoBehaviour
    {
        public Texture2D Crosshair;
        public Texture2D E_Hand_Image;
        public Texture2D FlashlightImage;

        public bool Hint_E = false;

        private bool NumberOnePressed = false;
        private bool Fl_Active = false;
        private bool light_fl = false;

        public Poc_Ray PlayerMainCamera;

        public GameObject FlashLight;
        public GameObject Light_FlashLight;

        void Start()
        {

        }


        void Update()
        {
            if (PlayerMainCamera._flashlight && Input.GetKeyDown(KeyCode.Alpha1))
            {
                NumberOnePressed = true;
                StartCoroutine("OffOneButton");
            } // Если фонарик подобран, и нажата кнопка 1, то открывается панель с фонариком

            if (NumberOnePressed && Input.GetKeyDown(KeyCode.Mouse0))
            {
                FlashLight.SetActive(true);
                Fl_Active = true;
                NumberOnePressed = false;
            } // Если фонарик выбран на панели, то он появляется в руках
            if (Fl_Active == true && Input.GetKeyDown(KeyCode.Mouse0) && light_fl == false)
            {
                light_fl = true;
            } // Если нажата кнопка мыши, и свет выключен, то свет включается
            else if(Fl_Active == true && Input.GetKeyDown(KeyCode.Mouse0) && light_fl == true)
            {
                light_fl = false;
            } // Если нажата кнопка мыши, и свет включен, свет отключается
            else if (Fl_Active == false)
            {
                light_fl = false;
            } // Если фонарика нет в руках, свет не работает
            if (light_fl)
            {
                Light_FlashLight.SetActive(true);
            } // Если свет фонарика включен, то он работает
            else if(light_fl == false)
            {
                Light_FlashLight.SetActive(false);
            } // Если свет у фонарика отключен, то он не работает
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Fl_Active = false;
                FlashLight.SetActive(false);
            } // Отключение фонарика
        }

        void OnGUI()
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 25, 25), Crosshair);

            if(Hint_E)
            {
                GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + 35, 100, 100), E_Hand_Image);
            }

            if(NumberOnePressed)
            {
                GUI.Box(new Rect(400, 50, 200, 150), "");
                GUI.BeginGroup(new Rect(400, 50, 200, 150));
                GUI.Label(new Rect(20, 20, 160, 110), FlashlightImage);
                GUI.EndGroup();
            }
        }
        IEnumerator OffOneButton()
        {
            yield return new WaitForSeconds(3);

            NumberOnePressed = false;
        }
    }
}