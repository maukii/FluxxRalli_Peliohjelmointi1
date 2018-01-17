using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

    public int amountX;
    public int amountZ;

    public float spacingX;
    public float spacingZ;

    public GameObject[] tile;

    void Start()
    {
        GridGeneration();
    }

    // Use this for initialization
    void GridGeneration()
    {
        for (int y = 0; y < amountX; y++)
        {
            for (int x = 0; x < amountZ; x++)
            {
                Vector3 spawnPos = new Vector3(0 + x * (1 + spacingX), 0, 0 + y * (1 + spacingZ));
                GameObject spawnPoint = Instantiate(new GameObject(), spawnPos, Quaternion.identity);
                //GameObject g = Instantiate(tile, spawnPos, Quaternion.identity) as GameObject;
                //g.name = x + "/" + y;
                //g.transform.parent = gameObject.transform;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
