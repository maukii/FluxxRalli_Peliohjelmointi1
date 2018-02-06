using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    /*
     *
     *  Track connections, what can be spawned on this block (not the other way around!)
     *  
     *             straightUP   straightL   straightrR  corner01    corner02    corner03    corner04
     *  straightUP      x           -           -           x           x           -           -      
     *  straightL       -           x           -           -           -           -           x
     *  straightR       -           -           x           -           -           x           -
     *                  
     *  corner01        -           -           x           -           -           x           -            
     *  corner02        -           x           -           -           -           -           x        
     *  corner03        x           -           -           x           x           -           -        
     *  corner04        x           -           -           x           x           -           -
     * 
    */

    public int amountX;
    public int amountZ;

    public int trackLenght;

    public float spacingX;
    public float spacingZ;

    public GameObject[] tile;

    public GameObject straight01, straight02, corner01, corner02, corner03, corner04;

    public Vector3 spawnPosition;

    public GameObject[] stU;
    public GameObject[] stL;
    public GameObject[] stR;

    public GameObject[] cr01;
    public GameObject[] cr02;
    public GameObject[] cr0304;

    int rnd;

    public GameObject startTile;

    void Start()
    {
        //GridGeneration();
        //LinearGeneration();
        newGen();
    }

    void newGen()
    {
        //Luo starttitilen ja asettaa sen currentTileksi
        GameObject startPoint = Instantiate(startTile, spawnPosition, Quaternion.identity);
        GameObject currentTile = startPoint;

        int i = 0;

        while (i < trackLenght)
        {
            if (currentTile == startPoint)
            {
                GameObject newTile = Instantiate(straight01, currentTile.transform.GetChild(0).position, straight01.transform.rotation);
                currentTile = newTile;
                Debug.Log(currentTile); 
            }

            else if (currentTile.tag == "straightUp")
            {
                var ThisSet = stU;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
                Debug.Log(ThisSet);
            }

            else if (currentTile.tag == "straightLeft")
            {
                var ThisSet = stL;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
                Debug.Log(ThisSet);
            }

            else if (currentTile.tag == "straightRight")
            {
                var ThisSet = stR;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
                Debug.Log(ThisSet);
            }

            else if (currentTile.tag == "corner01")
            {
                var ThisSet = cr01;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
                Debug.Log(ThisSet);
            }

            else if (currentTile.tag == "corner02")
            {
                var ThisSet = cr02;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
                Debug.Log(ThisSet);
            }

            else if (currentTile.tag == "corner03-04")
            {
                var ThisSet = cr0304;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
                Debug.Log(ThisSet);
            }

            else
                Debug.Log("Uh oh!");
                Debug.Log(currentTile.name);

            i++;
        }
    }
}
