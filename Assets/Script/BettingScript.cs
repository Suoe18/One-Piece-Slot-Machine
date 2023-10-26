using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingScript : MonoBehaviour
{
    public static BettingScript instance;

    [SerializeField]
    public Text playerCoinsUI;

    [SerializeField]
    Text totalBetUI;

    [SerializeField]
    AudioSource decreaseSound;

    [SerializeField]
    AudioSource increaseSound;
    
    

    public int playerCoins;
    public int totalBet;
    public int currentCoins;
    public int coinHolder;
    public int betHolder;
    

    int holderCounter = 1;

    public bool canPlay = true;

    void Start()
    {
        instance = this;
        playerCoinsUI.text = "1000000";
        playerCoins = int.Parse(playerCoinsUI.text);        
    }

    void Update()
    {
        playerCoins = int.Parse(playerCoinsUI.text);
        totalBet = int.Parse(totalBetUI.text);

        if (playerCoins > 0 && totalBet > 0)
        {
            canPlay = true;
        }
        if (playerCoins > totalBet && totalBet > 0)
        {
            canPlay = true;
        }
        if (coinHolder < totalBet)
        {
            canPlay = false;
        }

        if (playerCoins <= 0)
        {
            playerCoinsUI.text = "0";
        }
    }

    public void increaseBet()
    {       
        totalBet += 5000;
        increaseSound.Play();
        if (totalBet > 20000)
        {
            totalBet = 100000;
        }

        totalBetUI.text = totalBet.ToString();
    }

    public void decreaseBet()
    {
        totalBet -= 5000;
        decreaseSound.Play();
        if (totalBet <= 0)
        {
            totalBet = 0;
        }
        if (totalBet > 20000)
        {
            totalBet -= 75000;
        }
        totalBetUI.text = totalBet.ToString();
    }

    public void deductToPlayerCoins()
    {

        totalBet = int.Parse(totalBetUI.text);
        if (playerCoins != 0)
        {
            if (holderCounter <= 1)
            {
                coinHolder = playerCoins;
                betHolder = totalBet;
                holderCounter = 2;
            }
            if (totalBet > playerCoins)
            {
                currentCoins = currentCoins;
            }
            else
            {
                currentCoins = playerCoins - totalBet;
            }

            playerCoinsUI.text = currentCoins.ToString();
        }
    }

    public void deductToCoinHolder()
    {        
        if (holderCounter >= 2)
        {
            coinHolder -= betHolder;
        }
        if (coinHolder <= 0)
        {
            canPlay = false;
        }
        holderCounter = 1;
    }

    
}
