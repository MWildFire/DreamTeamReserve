using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public bool isLoad;
    private bool isOn = true;
    private bool isPressed;
    public GameObject text;

    public GameObject Image;

    void Update()
    {
        // ====================== Картинка в заставке ======================

        if(isOn == true)
        {
            StartCoroutine("Timer2");
        }

        // =================================================================



        // ====================== Пропуск заставки ======================
        if (isLoad)
        {
            SceneManager.LoadScene(1);
        }

        if (isPressed == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }

        else if (isPressed == false && Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Timer1");
        }

        // ===============================================================
    }

    IEnumerator Timer1()
    {
        text.SetActive(true);
        isPressed = true;
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
        isPressed = false;
    }
    IEnumerator Timer2()
    {
        yield return new WaitForSeconds(15f);
        Image.SetActive(true);
        yield return new WaitForSeconds(6f);
        Image.SetActive(false);
        isOn = false;
    }
}
