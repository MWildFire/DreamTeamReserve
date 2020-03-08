using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour
{
    private bool isOn;
    private bool isPressed;
    public GameObject text;
    void Update()
    {
        
        if (isOn)
        {
            SceneManager.LoadSceneAsync(0);
        }

        if (isPressed == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }

        else if (isPressed == false && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Timer1");
        }
    }

    IEnumerator Timer1()
    {
        text.SetActive(true);
        isPressed = true;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
        isPressed = false;
    }
}
