using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class KillBox : NetworkBehaviour
{
    public Text winText;
    //    public Transform player;



    private void Start()
    {
        winText.text = "";
    }

    void Update ()
    {

        //FindPlayer();
        // Follow player on x and z
        // Vector3 follow = new Vector3(player.transform.position.x, 0, player.transform.position.z);


    }

    void FindPlayer()
    {
//        Vector3 follow = new Vector3(player.transform.position.x, 0, player.transform.position.z);


    }

    void OnTriggerEnter(Collider other)
    {

        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        if (other.gameObject.tag == "Player")
        {
            if (isLocalPlayer == true)
            {
                winText.text = "You lose";
                Destroy(other.gameObject);
            }
            else
            {
                winText.text = "You Win";
            }
        }
    }
    

}
