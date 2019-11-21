using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavTutPlayeController : MonoBehaviour
{

    public Camera main;

    public UnityEngine.AI.NavMeshAgent agent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
          Ray ray = main.ScreenPointToRay(Input.mousePosition);
          RaycastHit hit;

          if (Physics.Raycast(ray, out hit)) {
            agent.SetDestination(hit.point);
          }
        }
    }
}
