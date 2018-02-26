using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDestroyer : MonoBehaviour {
    //Riikka's script hands off
    IEnumerator DestroyDelay()
    {
        List<GameObject> allTiles = GetComponent<EndlessTrackGenerator>().allTiles;
        GameObject toBeDestroyed = allTiles[0];

        Debug.Log("waiting...");
        yield return new WaitForSeconds(1);

        toBeDestroyed.AddComponent<Rigidbody>();

        Debug.Log("waiting...again");
        //yield return new WaitForSeconds(1);

        //Destroy(toBeDestroyed);
        allTiles.RemoveAt(0);

    }
}
