using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyMessages : MonoBehaviour
{
    public float time = 0.5f;

    void Update()
    {
        Destroy(gameObject, time);
    }
}
