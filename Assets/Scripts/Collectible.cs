using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Collectible : NetworkBehaviour
{

    //  Janne Viitala

    public Animator pickUps;
    public Animation Artifact_Pickup;
    public Animation Coin_Pickup;
    //jos aktivoituu, lisää pelaajan ItemCounteriin yhden itemin.

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            if (gameObject.tag == "Coin")
            {
                other.GetComponent<PlayerMovement>().coins++;
                Debug.Log("Coin collected");
                MeshCollider.Destroy(this);
                Coin_Pickup.Play();
                StartCoroutine(die());
            }
        }
    }
    
    public IEnumerator die()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}