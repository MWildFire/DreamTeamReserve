using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoTrackingEnemy : MonoBehaviour
{
    private NavMeshAgent vrag;
    public GameObject player;


    void Start()
    {
        vrag = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 2.0f)
            {
                Debug.Log("Тебя ударили!");
            }
            else if (distance < 6f)
            {
                vrag.destination = player.transform.position;
            }
        }

    }
}
