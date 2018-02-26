using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullLevelGenerator : MonoBehaviour
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

    public int trackLenght, chunkSize = 25;

    Vector3 spawnPosition;

    bool startSpawned = false;

    GameObject currentTile;
    GameObject startPoint;

    int rnd;

    public List<GameObject> allTiles = new List<GameObject>();

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
        currentTile = startPoint;
        allTiles.Add(startPoint);
        Debug.Log("Start added");

        //spawnaa suoran tilen startin jatkoksi
        GameObject startStraight = Instantiate(straightR, currentTile.transform.GetChild(0).position, Quaternion.identity);
        startStraight.transform.parent = gameObject.transform;
        currentTile = startStraight;
        allTiles.Add(startStraight);
        Debug.Log("Straight added");

        for (int i = 0; i < chunkSize + 5; i++)
        {
            if (currentTile.tag == "straightUp")
            {
                var ThisSet = stU;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "straightLeft")
            {
                var ThisSet = stL;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "straightRight")
            {
                var ThisSet = stR;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);

            }

            else if (currentTile.tag == "corner01")
            {
                var ThisSet = cr01;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "corner02")
            {
                var ThisSet = cr02;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "corner03")
            {
                var ThisSet = cr03;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "corner04")
            {
                var ThisSet = cr04;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else
            {
                Debug.Log("Something went wrong with the EndlessTrackGenerator: suitable tile not found");     //Debug, joka tulee jos ei löydetä sopivaa tileä (useimmiten johtuu siitä, että tileä ei ole asetettu inspectorissa)
            }
        }

        NewChunkOnTrigger();
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
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "straightLeft")
            {
                var ThisSet = stL;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "straightRight")
            {
                var ThisSet = stR;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "corner01")
            {
                var ThisSet = cr01;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "corner02")
            {
                var ThisSet = cr02;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "corner03")
            {
                var ThisSet = cr03;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else if (currentTile.tag == "corner04")
            {
                var ThisSet = cr04;
                rnd = Random.Range(0, ThisSet.Length);
                GameObject newTile = Instantiate(ThisSet[rnd], currentTile.transform.GetChild(0).position, ThisSet[0].transform.rotation);
                newTile.transform.parent = gameObject.transform;
                currentTile = newTile;
                allTiles.Add(newTile);
            }

            else
            {
                Debug.Log("Something went wrong with the EndlessTrackGenerator: suitable tile not found");     //Debug, joka tulee jos ei löydetä sopivaa tileä (useimmiten johtuu siitä, että tileä ei ole asetettu inspectorissa)
            }
        }

        GameObject endBlock = GameObject.CreatePrimitive(PrimitiveType.Cube);
        endBlock.transform.position = new Vector3(currentTile.transform.GetChild(0).position.x, currentTile.transform.GetChild(0).position.y + 1, currentTile.transform.GetChild(0).position.z);
        

        //StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        GameObject toBeDestroyed = allTiles[0];

        yield return new WaitForSeconds(1);

        toBeDestroyed.AddComponent<Rigidbody>();

        allTiles.RemoveAt(0);

    }
}

