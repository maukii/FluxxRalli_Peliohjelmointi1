/*using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityStandardAssets.Networking;

public class PlayerColor_Hook : LobbyHook
{

    public override void OnLobbyServerSceneloadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<NetworkLobbyPlayer>();
        PlayerColor player = gamePlayer.GetComponent<PlayerColor>();

        player.color = lobby.playerColor;
    }
	
}
*/
