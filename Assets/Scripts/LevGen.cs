using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevGen : MonoBehaviour {

    public GameObject[] tile;

    public int amountX;
    public int amountZ;

    public float trackSpacingX;
    public float trackSpacingZ;

    // Use this for initialization
    void Start()
    {
        for (int y = 0; y < amountX; y++)
        {
            for (int x = 0; x < amountZ; x++)
            {
                Vector3 spawnPos = new Vector3(0 + x * (1 + trackSpacingX), 0, 0 + y * (1 + trackSpacingZ));

                //GameObject g = Instantiate(new GameObject(), spawnPos, Quaternion.identity) as GameObject;
                GameObject g = Instantiate(tile[0], spawnPos, Quaternion.identity) as GameObject;         //creates new tiles from tile-array
                //g.name = x + "/" + y;
                g.transform.parent = gameObject.transform;
            }
        }
    }
}
