using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Menu : MonoBehaviour
{
    public GameObject GamePanel;
    public GameObject OptionsPanel;
    public GameObject AudioPanel;
    void Start()
    {
        
    }

    
    void Update()
    {

    }

    public void Game()
    {
        GamePanel.SetActive(true);
        OptionsPanel.SetActive(false);
        AudioPanel.SetActive(false);
    }
    public void Options()
    {
        GamePanel.SetActive(false);
        OptionsPanel.SetActive(true);
        AudioPanel.SetActive(false);
    }
    public void Audio()
    {
        GamePanel.SetActive(false);
        OptionsPanel.SetActive(false);
        AudioPanel.SetActive(true);
    }
}
