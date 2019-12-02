using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lol
{
    public class SecondRay : MonoBehaviour
    {
        public int CollectedPictures = 0;
        public Text CollectedText;
        void Start()
        {

        }


        void Update()
        {


            int Mask_Pictures = 1 << 11;

            RaycastHit info;
            Ray _ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(_ray, out info, 2.5f, Mask_Pictures))
            {
                /*Player_GUI.Hint_E = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Player_GUI.Hint_E = false;
                    CollectedPictures += 1;
                    Destroy(info.collider.gameObject);
                }
                
            }
            else
            {
                Player_GUI.Hint_E = false;
            }

            CollectedText.text = "Собрано: " + CollectedPictures.ToString();*/
            }
        }   
    }
}