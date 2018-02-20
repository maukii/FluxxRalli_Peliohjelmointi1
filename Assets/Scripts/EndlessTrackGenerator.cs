﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTrackGenerator : MonoBehaviour
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

    GameObject[] stU, stL, stR, cr01, cr02, cr03, cr04;

    public GameObject straightUP, straightL, straightR, corner01, corner02, corner03, corner04, startTile;

    public int trackLenght, chunkSize = 5;

    Vector3 spawnPosition;

    bool startSpawned = false;

    GameObject currentTile;
    GameObject startPoint;

    int rnd;

    Transform playerTransform;

    void Start()
    {
        // Tää fiksaa NullReferenceExceptionin ----v
        stU = new GameObject[] { straightUP, corner01, corner02, };
        stL = new GameObject[] { straightL, corner04 };
        stR = new GameObject[] { straightR, corner03, };

        cr01 = new GameObject[] { straightR, corner03 };
        cr02 = new GameObject[] { straightL, corner04 };
        cr03 = new GameObject[] { straightUP, corner01, corner02 };
        cr04 = new GameObject[] { straightUP, corner01, corner02 };

        StartChunk();
    }

    void StartChunk()
    {
        //Spawnaa start tilen
        GameObject startPoint = Instantiate(startTile, spawnPosition, Quaternion.identity);
        startPoint.transform.parent = gameObject.transform;
        GameObject currentTile = startPoint;

        //spawnaa suoran tilen startin jatkoksi
        GameObject startStraight = Instantiate(straightR, currentTile.transform.GetChild(0).position, Quaternion.identity);
        startStraight.transform.parent = gameObject.transform;
        currentTile = startStraight;

        for (int i = 0; i < chunkSize; i++)
        {
            if (currentTile.tag == "straightUp")
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
                Debug.Log("Something went wrong with the EndlessTrackGenerator: suitable tile not found");     //Debug, joka tulee jos ei löydetä sopivaa tileä (useimmiten johtuu siitä, että tileä ei ole asetettu inspectorissa)
            }
        }
    }

    public void NewChunkOnTrigger()
    {
        Debug.Log("New chunk called");

        //spawnaa kokonaisen chunkin
        for (int i = 0; i < chunkSize; i++)
        {
            if (currentTile.tag == "straightUp")
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
                Debug.Log("Something went wrong with the EndlessTrackGenerator: suitable tile not found");     //Debug, joka tulee jos ei löydetä sopivaa tileä (useimmiten johtuu siitä, että tileä ei ole asetettu inspectorissa)
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            Debug.Log("Collision with player");

            //spawnaa kokonaisen chunkin
            for (int i = 0; i < chunkSize; i++)
            {
                if (currentTile.tag == "straightUp")
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
                    Debug.Log("Something went wrong with the EndlessTrackGenerator: suitable tile not found");     //Debug, joka tulee jos ei löydetä sopivaa tileä (useimmiten johtuu siitä, että tileä ei ole asetettu inspectorissa)
                }
            }
        }
    }
}
