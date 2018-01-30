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
     *  straight02      -           X           X           -           -           X   
     *                     
     *  corner01        X           -           -           -           X           X        
     *  corner02        X           -           -           -           X           X        
     *  corner03        -           X           X           -           -           X
     *  corner04        -           X           -           X           X           -
     * 
    */

    public int amountX;
    public int amountZ;

    public int trackLenght;

    public float spacingX;
    public float spacingZ;

    public GameObject[] tile;

    public GameObject[] ST01;
    public GameObject[] ST02;

    public GameObject[] CR01;
    public GameObject[] CR02;
    public GameObject[] CR03;
    public GameObject[] CR04;

    public GameObject testTile;

    public GameObject startTile;

    void Start()
    {
        //GridGeneration();
        LinearGeneration();
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

        GameObject startPoint = Instantiate(startTile, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject currentTile = startPoint;

        int i = 0;

        while (i < 1)
        {

            while (i < 10)
            //for (int tl = 0; tl < trackLenght; tl++)
            {

                
              int randomTile = Random.Range(0, 1);
          //
          //              if (currentTile == tile[0])
          //              {
          //                  randomTile = Random.Range(0, ST01.Length);
          //              }
          //     
          //              else if (currentTile == tile[1])
          //              {
          //                  randomTile = Random.Range(0, ST02.Length);
          //              }
          //     
          //              else if (currentTile == tile[2])
          //              {
          //                  randomTile = Random.Range(0, CR01.Length);
          //              }
          //     
          //              else if (currentTile == tile[3])
          //              {
          //                  randomTile = Random.Range(0, CR02.Length);
          //              }
          //     
          //              else if (currentTile == tile[4])
          //              {
          //                  randomTile = Random.Range(0, CR03.Length);
          //              }
          //     
          //              else if (currentTile == tile[5])
          //              {
          //                  randomTile = Random.Range(0, CR04.Length);
          //              }

                //
                //          GameObject newTile = Instantiate(tile[0], currentTile.transform.GetChild(0).position, Quaternion.identity);
                //          newTile.transform.position = currentTile.transform.GetChild(0).position;


                // v --- TOIMII !!!!! ---v
                //Okei, vaatii sen että ratapalasen parenttiobjekti on snappipala ja trakkipalan ensimmäinen lapsi on seuraavan projektin spawnipaikka
                //eli nykyisen gameobjektin tyhjä parenttiobjekti sekä edellisen palikan ensimmäinen lapsiobjekti alignaavat

                GameObject currentTest = Instantiate(tile[randomTile], currentTile.transform.GetChild(0).position, tile[randomTile].transform.rotation);
                //Debug.Log("tile number: " + randomTile + " " + i + "  And currentTile: " + currentTile);
                currentTile = currentTest;

                //Tällä spawnilogiikalla joka toinen tile (jso kyseessä suoria tilejä) osuu kohdaleen. how to fix???
                //also, muokataan niin että jokaisen track-palan parentti (nimellä esim. TR_straight01) on kohdassa, jonne seuraava tile spawnaa

                //newTile.transform.position = startPoint.transform.

                i++;
            }
        }
    }

    void EndlessGeneration()
    {

        Instantiate(tile[0], startTile.transform.GetChild(0).position, Quaternion.identity);
    }
}
