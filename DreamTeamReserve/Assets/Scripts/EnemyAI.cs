using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour
{
    public Transform[] pos;


    private NavMeshAgent agent;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        int value = Random.Range(0, 3);
        if (other.gameObject.CompareTag("Point"))
        {
            agent.destination = pos[value].position;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
