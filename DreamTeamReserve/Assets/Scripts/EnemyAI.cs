using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace game
{
    public class EnemyAI : MonoBehaviour
    {
        public Transform[] pos;
        public int value = Random.Range(0, 3);
        public int CurrentPoint;

        public NavMeshAgent agent;



        // Start is called before the first frame update
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.destination = pos[value].position;
        }

        

        // Update is called once per frame
        void Update()
        {

        }
    }
}