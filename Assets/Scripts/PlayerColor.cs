using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerColor : NetworkBehaviour
{

    //  Mauno Kiiskinen

    [SyncVar]
    public Color color; // For choosing player's color

    MeshRenderer[] rends; // Array to store mesh renderers of the player

	void Start ()
    {
        rends = GetComponentsInChildren<MeshRenderer>();
        for(int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = color;
        }
	}


    void HidePlayer()
    {
		// Loop through MeshRenderers and set them to Clear
        for (int i = 0; i < rends.Length; i++)
        {
            rends[i].material.color = Color.clear;
        }
	}
}
