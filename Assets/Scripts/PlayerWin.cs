using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerWin : NetworkBehaviour
{
    Text informationText;
    public bool goalHit;

    [ClientRpc]
    void RpcDie()
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

    [ClientRpc]
    void RpcWin()
    {
        informationText = GameObject.FindObjectOfType<Text>();

        if (!isLocalPlayer)
        {
            informationText.text = "Game Over";
        }
        else
        {
            informationText.text = "You Win";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "KillBox")
        {
            RpcDie();
            Invoke("BackToLobby", 3f);
            return;
        }

        if(other.gameObject.tag == "Goal")
        {
            RpcWin();
            Invoke("BackToLobby", 1f);
            return;
        }
    }

    void BackToLobby()
    {
        FindObjectOfType<NetworkLobbyManager>().ServerReturnToLobby();
    }

}
