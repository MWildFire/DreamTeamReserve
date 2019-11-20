using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadacha2 : MonoBehaviour {
    public int N;
    private int Rez;

	void Start () {

	}

    void Update() {
        int[] Zadachka2 = new int[N];
        for (int i = 0; i < N; i++)
        {
            Zadachka2[i] = Random.Range(1, 100);
        }
        for(int z = 0; z < N; z++)
        {
            if (z != N)
            {
                Rez += Zadachka2[z];
            }
        }
	}
}
