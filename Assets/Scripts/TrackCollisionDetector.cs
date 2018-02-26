using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCollisionDetector : MonoBehaviour {

    bool TrackCollision;
	
	void OnTriggerEnter (Collider other)
    {
        if (other.tag == "straightUp" || other.tag == "straightLeft" || other.tag == "straightRight" || other.tag == "corner01" || other.tag == "corner02" || other.tag == "corner03" || other.tag == "corner04")
        {
            Debug.Log("Track Collision detected");
            other.GetComponent<Collider>().enabled = false;
            GameObject.FindGameObjectWithTag("LevelGenerator").GetComponent<EndlessTrackGenerator>().NewChunkOnTrigger();
        }

        else
        {
            Debug.Log("Unknown Collision");
        }
	}
}
