using UnityEngine;
using System.Collections;
using UnityEngine.UI;




//Koodin kirjoittanut Janne Viitala 6.2.2018
//




public class StartCountdown : MonoBehaviour
{
    public int timeLeft = 3;
    public Text countdownText;
    public GameObject Player;
    PlayerMovement script;
   

    void Start()
    {
        StartCoroutine("CountDown");
        script = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        countdownText.text = ("" + timeLeft);

        if (timeLeft == 0)
        {
            countdownText.text = "GO";
            script.enabled = true;
            
        }


        if (timeLeft == -1)
        {
            countdownText.text = ("");
            StopCoroutine("CountDown");

        }


    }



    IEnumerator CountDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

}