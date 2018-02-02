using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{

    /*  Track connections, what can be spawned on this block (not the other way around!)
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
    */

    public int trackLenght;

    public Vector3 spawnPosition;

    public GameObject[] stU, stL, stR, cr01, cr02, cr0304;

    int rnd;

    public GameObject startTile;        //start-tile, jossa lähtöruutu
    public GameObject straightUp;       //startin jälkeen aina luotava tile

    void Start()
    {
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
                GameObject newTile = Instantiate(straightUp, currentTile.transform.GetChild(0).position, straightUp.transform.rotation);
                currentTile = newTile;
            }

            else if (currentTile.tag == "straightUp")
            {
                var ThisSet = stU;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
            }

            else if (currentTile.tag == "straightLeft")
            {
                var ThisSet = stL;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
            }

            else if (currentTile.tag == "straightRight")
            {
                var ThisSet = stR;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
            }

            else if (currentTile.tag == "corner01")
            {
                var ThisSet = cr01;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
            }

            else if (currentTile.tag == "corner02")
            {
                var ThisSet = cr02;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
            }

            else if (currentTile.tag == "corner03-04")
            {
                var ThisSet = cr0304;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                currentTile = newTile;
            }

            else
            {
                Debug.Log("Something went wrong with the TrackGenerator: suitable tile not found");     //Debug, joka tulee jos ei löydetä sopivaa tileä (useimmiten johtuu siitä, että tileä ei ole asetettu inspectorissa)
            }

            i++;

        }

        // spawn maaliviiva
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = currentTile.transform.GetChild(0).position + new Vector3(0,2,0);
        Debug.Log("end not spawned");
    }
}

