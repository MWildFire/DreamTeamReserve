using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NMA : MonoBehaviour
{
    public NavMeshAgent vrag;
    public GameObject Player;


    void Start()
    {
        vrag = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (Player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 2.0f)
            {
                Debug.Log("Поц тебя ударил");
            }
            else if (distance < 6f)
            {
                vrag.destination = player.transform.position;
            }
        }

    }
}
