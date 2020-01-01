using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstFirst : MonoBehaviour
{
    public int MainMenuSceneId = 1;
    public GameObject Black2;
    public Image Black2Again;
    public float Alpha = 0f;
    private bool Can = false;


    void Start()
    {
        Black2.SetActive(false);
        StartCoroutine("StartLogo");
    }

    void Update()
    {
        if (Can)
        {
            if(Alpha <= 1f)
            {
                Alpha += 0.01f;
            }
        }
        Black2Again.color = new Color(Black2Again.color.r, Black2Again.color.g, Black2Again.color.b, Alpha);
        if (Alpha >= 1f)
        {
            SceneManager.LoadSceneAsync(MainMenuSceneId);
        }
    }

    IEnumerator StartLogo()
    {
        yield return new WaitForSeconds(1f);
        Black2.SetActive(true);
        Can = true;
    }
}
