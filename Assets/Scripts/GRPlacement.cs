using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRPlacement : MonoBehaviour {

    //Määrittää, mikä sijoitus täytyy olla kun ylittää maaliviivan

    int[] Placement = new int[] { 1, 2, 3, 4 };
    static Random rnd = new Random();

    void Start()
    {
        int mynumber = Random.Range(0, Placement.Length);

        Debug.Log(mynumber);
    }


}
