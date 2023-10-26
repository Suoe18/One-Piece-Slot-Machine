using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinningScript : MonoBehaviour
{
    public static WinningScript instance;
    [SerializeField]
    Image[] reelOneSprites;

    [SerializeField]
    Image[] reelTwoSprites;

    [SerializeField]
    Image[] reelThreeSprites;

    [SerializeField]
    Image[] reelFourSprites;

    [SerializeField]
    Image[] reelFiveSprites;

    [SerializeField]
    Image[] rowOne;

    [SerializeField]
    Image[] rowTwo;

    [SerializeField]
    Image[] rowThree;

    [SerializeField]
    Sprite[] onePieceSymbol;

    [SerializeField]
    public Text totalWinningUI;

    [SerializeField]
    AudioSource winSound;

    public int totalWinnings;
    public int sumOfTotalWinnings;
    public int totalPayOut;

    int sumCounter = 1;

    bool hasPayOut = false;

    //Lines Counter
    int reelOneOccurenceCounter = 0;
    int reelTwoOccurenceCounter = 0;
    int reelThreeOccurenceCounter = 0;    
            
    int reelOneRowOnePayOutSymbol;
    int reelOneRowTwoPayOutSymbol;
    int reelOneRowThreePayOutSymbol;

    int luffyCounter = 0, zoroCounter = 0, namiCounter = 0, usoppCounter = 0, sanjiCounter = 0;
    int chopperCounter = 0, robinCounter = 0, frankyCounter = 0, brookCounter = 0, jimbeiCounter = 0;

    int luffyPayOut = 0, zoroPayOut = 0, namiPayOut = 0, usoppPayOut = 0, sanjiPayOut = 0;
    int chopperPayOut = 0, robinPayOut = 0, frankyPayOut = 0, brookPayOut = 0, jimbeiPayOut = 0;

    public int checkingCounter = 1;

    void Start()
    {
        instance = this;
    }
    
    void Update()
    {
        if(checkingCounter <= 1)
        {
            reelOneSymbolChecker();
            lineOneChecker();
            lineTwoChecker();
            lineThreeChecker();            

            if (sumOfTotalWinnings > 0)
            {
                hasPayOut = true;
            }

            if (hasPayOut)
            {
                winSound.Play();
                totalWinningUI.text = sumOfTotalWinnings.ToString();
                BettingScript.instance.playerCoins += sumOfTotalWinnings;
                BettingScript.instance.playerCoinsUI.text = BettingScript.instance.playerCoins.ToString();
                resetPayOutValue();
            }           

            checkingCounter = 100;
        }
        else
        {
            reelOneOccurenceCounter = 0;
            reelTwoOccurenceCounter = 0;
            reelThreeOccurenceCounter = 0;            
            resetPayOutValue();           
        }
    }

    public void reelOneSymbolChecker()
    {               
        for(int i = 0; i < onePieceSymbol.Length; i++)
        {
            if(reelOneSprites[0].sprite == onePieceSymbol[i])
            {                
                reelOneRowOnePayOutSymbol = i;
            }
            if (reelOneSprites[1].sprite == onePieceSymbol[i])
            {                
                reelOneRowTwoPayOutSymbol = i;
            }
            if (reelOneSprites[2].sprite == onePieceSymbol[i])
            {                
                reelOneRowThreePayOutSymbol = i;
            }
        }                           
    }

    public void payOutSystem()
    {
        // Luffy Pay Out        
        if (luffyCounter == 3)
        {
            luffyPayOut += 2;
        }
        else if (luffyCounter == 4)
        {
            luffyPayOut += 6;
        }
        else if (luffyCounter == 5)
        {
            luffyPayOut += 12;
        }

        // Zoro Pay Out
        if (zoroCounter == 3)
        {
            zoroPayOut += 2;
        }
        else if (zoroCounter == 4)
        {
            zoroPayOut += 5;
        }
        else if (zoroCounter == 5)
        {
            zoroPayOut += 10;
        }

        // Nami Pay Out
        if (namiCounter == 3)
        {
            namiPayOut += 1;
        }
        else if (namiCounter == 4)
        {
            namiPayOut += 3;
        }
        else if (namiCounter == 5)
        {
            namiPayOut += 10;
        }

        // Usopp Pay Out
        if (usoppCounter == 3)
        {
            usoppPayOut += 1;
        }
        else if (usoppCounter == 4)
        {
            usoppPayOut += 2;
        }
        else if (usoppCounter == 5)
        {
            usoppPayOut += 12;
        }

        // Sanji Pay Out
        if (sanjiCounter == 3)
        {
            sanjiPayOut += 1;
        }
        else if (sanjiCounter == 4)
        {
            sanjiPayOut += 3;
        }
        else if (sanjiCounter == 5)
        {
            sanjiPayOut += 5;
        }

        // Chopper Pay Out
        if (chopperCounter == 3)
        {
            chopperPayOut += 2;
        }
        else if (chopperCounter == 4)
        {
            chopperPayOut += 4;
        }
        else if (chopperCounter == 5)
        {
            chopperPayOut += 6;
        }

        // Robin Pay Out
        if (robinCounter == 3)
        {
            robinPayOut += 2;
        }
        else if (robinCounter == 4)
        {
            robinPayOut += 5;
        }
        else if (robinCounter == 5)
        {
            robinPayOut += 10;
        }

        // Franky Pay Out
        if (frankyCounter == 3)
        {
            frankyPayOut += 2;
        }
        else if (frankyCounter == 4)
        {
            frankyPayOut += 7;
        }
        else if (frankyCounter == 5)
        {
            frankyPayOut += 8;
        }

        // Brook Pay Out
        if (brookCounter == 3)
        {
            brookPayOut += 1;
        }
        else if (brookCounter == 4)
        {
            brookPayOut += 6;
        }
        else if (brookCounter == 5)
        {
            brookPayOut += 10;
        }

        // Jimbei Pay Out
        if (jimbeiCounter == 3)
        {
            jimbeiPayOut += 2;
        }
        else if (jimbeiCounter == 4)
        {
            jimbeiPayOut += 5;
        }
        else if (jimbeiCounter == 5)
        {
            jimbeiPayOut += 15;
        }
        
    }
    
    public void lineOneChecker()
    {      
        for (int lineOneCounterI = 0; lineOneCounterI <= 4; lineOneCounterI++)
        {            
            if (rowOne[lineOneCounterI].sprite == onePieceSymbol[reelOneRowOnePayOutSymbol])
            {                                            
                switch (reelOneRowOnePayOutSymbol)
                {
                    case 0:
                        luffyCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 1:
                        zoroCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 2:
                        namiCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 3:
                        usoppCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 4:
                        sanjiCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 5:
                        chopperCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 6:
                        robinCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 7:
                        frankyCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 8:
                        brookCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                    case 9:
                        jimbeiCounter += 1;
                        reelOneOccurenceCounter += 1;
                        break;
                }

            }
            else
            {                
                if (reelOneOccurenceCounter < 4)
                {                    
                    lineOneCounterI = 5;                    
                }
                
                
            }                       
        }

        payOutSystem();        
        computeWinnings();        
    }

    public void lineTwoChecker()
    {     
        for (int lineTwoCounterI = 0; lineTwoCounterI <= 4; lineTwoCounterI++)
        {
            if (rowTwo[lineTwoCounterI].sprite == onePieceSymbol[reelOneRowTwoPayOutSymbol])
            {                
                switch (reelOneRowTwoPayOutSymbol)
                {
                    case 0:
                        luffyCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 1:
                        zoroCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 2:
                        namiCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 3:
                        usoppCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 4:
                        sanjiCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 5:
                        chopperCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 6:
                        robinCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 7:
                        frankyCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 8:
                        brookCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                    case 9:
                        jimbeiCounter += 1;
                        reelTwoOccurenceCounter += 1;
                        break;
                }
            }
            else
            {
                if (reelTwoOccurenceCounter < 4)
                {
                    lineTwoCounterI = 5;
                }
            }
        }

        payOutSystem();
        computeWinnings();
    }

    public void lineThreeChecker()
    {          
        for (int lineThreeCounterI = 0; lineThreeCounterI <= 4; lineThreeCounterI++)
        {
            if (rowThree[lineThreeCounterI].sprite == onePieceSymbol[reelOneRowThreePayOutSymbol])
            {                
                switch (reelOneRowThreePayOutSymbol)
                {
                    case 0:
                        luffyCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 1:
                        zoroCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 2:
                        namiCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 3:
                        usoppCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 4:
                        sanjiCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 5:
                        chopperCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 6:
                        robinCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 7:
                        frankyCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 8:
                        brookCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                    case 9:
                        jimbeiCounter += 1;
                        reelThreeOccurenceCounter += 1;
                        break;
                }
            }
            else
            {
                if (reelThreeOccurenceCounter < 4)
                {
                    lineThreeCounterI = 5;
                }
            }
        }

        payOutSystem();
        computeWinnings();
    }
    

    public void resetCounterValue()
    {
        luffyCounter = 0;        
        zoroCounter = 0;        
        namiCounter = 0;        
        usoppCounter = 0;        
        sanjiCounter = 0;        
        chopperCounter = 0;        
        robinCounter = 0;        
        frankyCounter = 0;        
        brookCounter = 0;        
        jimbeiCounter = 0;

        sumCounter = 1;
    }

    public void resetPayOutValue()
    {
        luffyPayOut = 0;
        zoroPayOut = 0;
        namiPayOut = 0;
        usoppPayOut = 0;
        sanjiPayOut = 0;
        chopperPayOut = 0;
        robinPayOut = 0;
        frankyPayOut = 0;
        brookPayOut = 0;
        jimbeiPayOut = 0;

        hasPayOut = false;        
    }

    public void computeWinnings()
    {
        totalWinnings = (BettingScript.instance.betHolder / 20);
        totalPayOut = luffyPayOut + zoroPayOut + namiPayOut + usoppPayOut + sanjiPayOut + chopperPayOut + robinPayOut + frankyPayOut + brookPayOut + jimbeiPayOut;        
        if (totalPayOut > 0)
        {            
            totalWinnings *= totalPayOut;
            if(sumCounter <= 1)
            {
                sumOfTotalWinnings += totalWinnings;
                resetPayOutValue();
                sumCounter = 2;
            }
            
        }        
                        
        resetCounterValue();        
    }
}
