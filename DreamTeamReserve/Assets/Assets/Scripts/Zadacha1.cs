using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadacha1 : MonoBehaviour {
    public int A = 10;
    public int B = 1;

    public int Rez;

	void Start () {
        Rez = A;
    }
	

	void Update () {
		for(int x = A; x > B; x--)
        {
            Rez -= 1;
            if(Rez % 2 == 1)
            {
                Debug.Log(Rez);
                
            }
        }
        
	}
}
