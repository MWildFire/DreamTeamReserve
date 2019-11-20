using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Game
{
    public class Player_Stats : MonoBehaviour
    {

        public int HP = 5;

        public GameObject SpriteHP0;
        public GameObject SpriteHP1;
        public GameObject SpriteHP2;
        public GameObject SpriteHP3;
        public GameObject SpriteHP4;
        public GameObject SpriteHP5;
        public GameObject DEADPANEL;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(HP == 5)
            {
                SpriteHP5.SetActive(true);
                SpriteHP4.SetActive(false);
                SpriteHP3.SetActive(false);
                SpriteHP2.SetActive(false);
                SpriteHP1.SetActive(false);
                SpriteHP0.SetActive(false);
            }
            else if(HP == 4)
            {
                SpriteHP5.SetActive(false);
                SpriteHP4.SetActive(true);
                SpriteHP3.SetActive(false);
                SpriteHP2.SetActive(false);
                SpriteHP1.SetActive(false);
                SpriteHP0.SetActive(false);
            }
            else if (HP == 3)
            {
                SpriteHP5.SetActive(false);
                SpriteHP4.SetActive(false);
                SpriteHP3.SetActive(true);
                SpriteHP2.SetActive(false);
                SpriteHP1.SetActive(false);
                SpriteHP0.SetActive(false);
            }
            else if (HP == 2)
            {
                SpriteHP5.SetActive(false);
                SpriteHP4.SetActive(false);
                SpriteHP3.SetActive(false);
                SpriteHP2.SetActive(true);
                SpriteHP1.SetActive(false);
                SpriteHP0.SetActive(false);
            }
            else if (HP == 1)
            {
                SpriteHP5.SetActive(false);
                SpriteHP4.SetActive(false);
                SpriteHP3.SetActive(false);
                SpriteHP2.SetActive(false);
                SpriteHP1.SetActive(true);
                SpriteHP0.SetActive(false);
            }
            else if (HP == 0)
            {
                SpriteHP5.SetActive(false);
                SpriteHP4.SetActive(false);
                SpriteHP3.SetActive(false);
                SpriteHP2.SetActive(false);
                SpriteHP1.SetActive(false);
                SpriteHP0.SetActive(true);
                DEADPANEL.SetActive(true);
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene(1);
                }
            }
        }

    }
}