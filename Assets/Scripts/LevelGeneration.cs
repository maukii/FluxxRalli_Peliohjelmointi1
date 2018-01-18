using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {

    /*
     *
     *  Track connections
     *  
     *             straight01  straight02  corner01    corner02    corner03    corner04
     *  straight01      X           -           X           X           -           -   
     *  straight02                  fuck u talukkko
     *  corner01
     *  corner02
     *  corner03
     *  corner04
     * 
    */ 

    public int amountX;
    public int amountZ;

    public float spacingX;
    public float spacingZ;

    public GameObject[] tile;
    public GameObject startTile;

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
                int randomTile = Random.Range(0, tile.Length);

                Vector3 spawnPos = new Vector3(0 + x * (1 + spacingX), 0, 0 + y * (1 + spacingZ));
                //GameObject spawnPoint = Instantiate(new GameObject(), spawnPos, Quaternion.identity);
                GameObject g = Instantiate(tile[randomTile], spawnPos, Quaternion.identity) as GameObject;
                //g.name = x + "/" + y;
                g.transform.parent = gameObject.transform;

                /*
                 * spawnaa tile
                 * spawnaa uusi_tile edellisen tilen liittymiskohtaan
                 * tilen liittymiskohta = minne auto voi mennä äksde
                 * 
                */
            }
        }
    }

    void LinearGeneration()
    {
        GameObject startPoint = Instantiate(startTile, new Vector3(0,0,0), Quaternion.identity);
        int randomTile = Random.Range(0, tile.Length);

        GameObject newTile = Instantiate(tile[randomTile], new Vector3(0, 0, 0), Quaternion.identity);
        //newTile.transform.position = startPoint.transform.
    }
}
