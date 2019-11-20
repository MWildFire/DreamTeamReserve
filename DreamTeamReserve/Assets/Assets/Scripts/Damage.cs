using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class Damage : MonoBehaviour {

        public bool OK = false;

        public Player_Stats Player;

        public int DMG = 1;

        
        void Start() {

        }

        
        void Update() {
            if (OK == true)
            {
                Player.HP -= 1;
                StartCoroutine("_Time");
                OK = false;
            }

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                OK = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                OK = false;
            }
        }




        IEnumerator _Time()
        {
            yield return new WaitForSeconds(2.0f);
            OK = true;
        }
    }
}