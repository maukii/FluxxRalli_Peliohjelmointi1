using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UserInterface : MonoBehaviour
{
    public bool win = false;
 
    public Text CoincountText;
    public Text ArtcountText;
    public Text PositionText;
    public Text winText;
    private int Coincount;
    private int Artcount;

    void Start()
    {

        Coincount = 0;
        Artcount = 0;
        SetCoinCountText();
        SetArtCountText();
        winText.text = "";
    }

    void Update()
    {
        if(win == true)
        {
            Win();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {

            Coincount = Coincount + 1;
            SetCoinCountText();
        }
        if (other.gameObject.CompareTag("Artifact"))
        {

            Artcount = Artcount + 1;
            SetArtCountText();
        }
    }

    void SetCoinCountText()
    {
        CoincountText.text = "Coins: " + Coincount.ToString();
    }
    //   if (count >= 12)
    //   {
    //       winText.text = "You Win!";
    //   }

    void SetArtCountText()
    {
        ArtcountText.text = "Items: " + Artcount.ToString();
    }

    void Win()
    {
       
        winText.text = "u win";
    }
}