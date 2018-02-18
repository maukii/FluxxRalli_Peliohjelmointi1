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

    GameObject[] stU, stL, stR, cr01, cr02, cr0304;

    public GameObject straightUP, straightL, straightR, corner01, corner02, corner03, corner04, startTile;

    public int trackLenght;

    public Vector3 spawnPosition;

    int rnd;

    void Start()
    {
        newGen();
    }

    void newGen()
    {
        GameObject[] stU = { straightUP, corner01, corner02, };
        GameObject[] stL = { straightL, corner04 };
        GameObject[] stR = { straightR, corner03, };

        GameObject[] cr01 = { straightR, corner03 };
        GameObject[] cr02 = { straightL, corner04 };
        GameObject[] cr03 = { straightUP, corner01, corner02 };
        GameObject[] cr04 = { straightUP, corner01, corner02 };


        //Luo starttitilen ja asettaa sen currentTileksi
        GameObject startPoint = Instantiate(startTile, spawnPosition, Quaternion.identity);
        startPoint.transform.parent = gameObject.transform;
        GameObject currentTile = startPoint;

        int i = 0;

        while (i < trackLenght)
        {
            if (currentTile == startPoint)
            {
                GameObject newTile = Instantiate(straightUP, currentTile.transform.GetChild(0).position, straightUP.transform.rotation);
                newTile.transform.parent = gameObject.transform;

                currentTile = newTile;
            }

            else if (currentTile.tag == "straightUp")
            {
                var ThisSet = stU;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
            }

            else if (currentTile.tag == "straightLeft")
            {
                var ThisSet = stL;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
            }

            else if (currentTile.tag == "straightRight")
            {
                var ThisSet = stR;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
            }

            else if (currentTile.tag == "corner01")
            {
                var ThisSet = cr01;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
            }

            else if (currentTile.tag == "corner02")
            {
                var ThisSet = cr02;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
            }

            else if (currentTile.tag == "corner03")
            {
                var ThisSet = cr03;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
            }

            else if (currentTile.tag == "corner04")
            {
                var ThisSet = cr04;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
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
        Debug.Log("end spawned");
    }
}

