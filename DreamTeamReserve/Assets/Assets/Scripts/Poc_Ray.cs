using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lol
{
    public class Poc_Ray : MonoBehaviour
    {
        public G_U_I GUI_Script;

        public bool _flashlight;

        void Start()
        {

        }


        void Update()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * 3f, Color.yellow);


            int Flashlight = 1 << 9;

            if (Physics.Raycast(ray, out hit, 3f, Flashlight))
            {
                GUI_Script.Hint_E = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    _flashlight = true;
                    Destroy(hit.collider.gameObject);
                }
            }
            else
            {
                GUI_Script.Hint_E = false;
            }
        }
    }
}