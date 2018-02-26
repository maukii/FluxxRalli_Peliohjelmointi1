using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerWin : NetworkBehaviour
{
    public Text informationText;
    public bool goalHit;

    [ClientRpc]
    void RpcWin()
    {
        informationText = GameObject.FindObjectOfType<Text>();

        if(isLocalPlayer)
        {
            informationText.text = "Game Over";
        }
        else
        {
            informationText.text = "You Win";
        }
    }

    private void Update()
    {
        if(goalHit == true)
        {
            RpcWin();
            Invoke("BackToLobby", 3f);
            return;
        }
    }

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }

}
