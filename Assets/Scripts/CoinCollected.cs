using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CoinCollected : NetworkBehaviour {

    public int coins = 0;

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Coins : " + coins);
    }

}
