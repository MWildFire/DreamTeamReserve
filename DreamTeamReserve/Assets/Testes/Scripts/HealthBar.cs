using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public void EditHealth(int value)
    {
        GetComponent<Slider>().value += value;
    }
}
