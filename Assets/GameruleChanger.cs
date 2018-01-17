using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameruleChanger : MonoBehaviour
{

    //jos aktivoituu, jokin satunnainen Gamerule muuttuu
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("Gamerule changed");

        }


        List<string> GRList = new List<string>();
        string[] GRArray = new string[5];

        // void RandomGR()
        //     {
        //     return new ("Placement", "Items", "Coins", "Clear", "Speed");
        //     }"Placement", "Items", "Coins", "Clear", "Speed"
        // 
        //     switch (RandomGR)
        //     {
        //         case Placement:
        //             Debug.Log("The color is red");
        //             break;
        //         case Items:
        //             Debug.Log("The color is green");
        //             break;
        //         case Coins:
        //             Debug.Log("The color is blue");
        //             break;
        //         case Clear:
        //             Debug.Log("The color is blue");
        //             break;
        //         case Speed:
        //             Debug.Log("The color is blue");
        //             break;
        //         default:
        //             Debug.Log("The color is unknown.");
        //             break;
    }
        Destroy(gameObject);
    



    }
}