using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game {
    public class EnemyPoints : MonoBehaviour
    {
        public EnemyAI vrag;

        void Start()
        {

        }


        void Update()
        {
            /*int value = Random.Range(0, 3);
            vrag.CurrentPoint = value;*/
        }

        private void OnTriggerEnter(Collider other)
        {
            vrag.value = Random.Range(0, 3);
            if (other.gameObject.tag == "Player")
            {
                vrag.agent.destination = vrag.pos[vrag.value].position;//vrag.CurrentPoint].position;
            }

        }
    }
}