using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Animation Artifact_Pickup;
    public Animation Coin_Pickup;
    //jos aktivoituu, lisää pelaajan ItemCounteriin yhden itemin.
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            if (gameObject.tag == "Artifact")
            {
                Debug.Log("Artifact collected");
                Artifact_Pickup.Play();
                
              
            }
            else
            {
                Debug.Log("Coin collected");
              
                Coin_Pickup.Play();
            }
        }
    }
    
    public void die()
    {
        Destroy(this.gameObject);
    }
}