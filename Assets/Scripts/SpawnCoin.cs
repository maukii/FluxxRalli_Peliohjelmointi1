using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour {

    //  Mauno Kiiskinen

    public Transform coinPos;
    public GameObject coinPrefab;
    int num;

    void Start()
    {
        num = Random.Range(0, 3);
        if(num == 0 || num == 1)
        {
            Instantiate(coinPrefab, coinPos);
        }
    }
}
