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
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            Ray ray = new Ray(vrag.gameObject.transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
                if (distance < 2.0f)
                {
                    Debug.Log("Поц тебя ударил");
                }
                else if (distance < 6f)
                {
                    vrag.destination = Player.transform.position;
                }
            }

        }

    }
}
