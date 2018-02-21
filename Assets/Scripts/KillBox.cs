using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    public Transform player;
	
	void Update ()
    {

        FindPlayer();
        // Follow player on x and z
        // Vector3 follow = new Vector3(player.transform.position.x, 0, player.transform.position.z);


    }

    void FindPlayer()
    {
        Vector3 follow = new Vector3(player.transform.position.x, 0, player.transform.position.z);


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
    // JANNE LAITA UI

}
