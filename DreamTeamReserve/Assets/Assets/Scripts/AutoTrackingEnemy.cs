using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AutoTrackingEnemy : MonoBehaviour
{
    private NavMeshAgent vrag;
    public GameObject player;

    public GameObject DeathPanel;
    public GameObject Player;

    private bool isDeath;

    void Start()
    {
        vrag = GetComponent<NavMeshAgent>();
        DeathPanel.SetActive(false);
    }


    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 2.0f)
            {
                //Debug.Log("Тебя ударили!");
                isDeath = true;
            }
            else if (distance < 15f)
            {
                vrag.destination = player.transform.position;
            }

            if (isDeath)
            {
                DeathPanel.SetActive(true);
                //Destroy(Player.gameObject);
                Player.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadSceneAsync(1);
                    DeathPanel.SetActive(false);
                    isDeath = false;
                }
            }
        }

    }
}
