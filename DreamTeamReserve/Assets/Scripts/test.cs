using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Dropdown ResolutionDropdown;
    Resolution[] res;

    void Start()
    {
        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();
        string[] strRes = new string[resolution.Length];
        for (int i = 0; i < res.Length; i++)
        {
            strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();
        }
        ResolutionDropdown.ClearOptions();
        ResolutionDropdown.AddOptions(strRes.ToList());
        Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, true);
    }

    
    public void SetRes()
    {
        Screen.SetResolution(res[ResolutionDropdown.value].width, res[ResolutionDropdown.value].height, true);
    }
}
