using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGeneration : MonoBehaviour {

    public GameObject[] trackParts; 

    public int trackPoints;
    public int trackAreaX, trackAreaZ;

    public double trackSpacingX, trackSpacingY;

	void Start ()
    {
        TrackSpawnPoints();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void TrackSpawnPoints()
    {
        int i = 0;

        while(i < trackPoints)
        {
            //Vector3 spawnGrid = new Vector3(0 + );
            Vector3 spawnpointSpawn = new Vector3(Random.Range(-trackAreaX, trackAreaX), 0, Random.Range(-trackAreaZ, trackAreaZ));

            Instantiate(trackParts[0], spawnpointSpawn + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            i++;
        }
    }
}
