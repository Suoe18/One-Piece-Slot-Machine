using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelsScript : MonoBehaviour
{
    public static ReelsScript instance;

    [SerializeField]
    Sprite[] chibiCrew;

    [SerializeField]
    Image RowOne;

    [SerializeField]
    Image RowTwo;

    [SerializeField]
    Image RowThree;

    [SerializeField]
    GameObject stopButton;

    [SerializeField]
    GameObject spinButton;
    
    float time = 0;
    public bool isSpinning;
    public bool isDone;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {        
        if(BettingScript.instance.canPlay)
        {
            Spin();
            time += Time.deltaTime;           
            if (time >= 2)
            {
                Stop();                
            }
        }                           
    }


    public void Spin()
    {
        RowOne.sprite = chibiCrew[Random.Range(0, chibiCrew.Length)];
        RowTwo.sprite = chibiCrew[Random.Range(0, chibiCrew.Length)];
        RowThree.sprite = chibiCrew[Random.Range(0, chibiCrew.Length)];

        isSpinning = true;
        isDone = false;
        
    }

    public void Stop()
    {
        enabled = false;
        time = 0;
        BettingScript.instance.deductToCoinHolder();
        isSpinning = false;
        isDone = true;
        WinningScript.instance.checkingCounter = 1;
        WinningScript.instance.totalWinningUI.text = "0";
        WinningScript.instance.totalWinnings = 0;
        WinningScript.instance.sumOfTotalWinnings = 0;
        spinButton.SetActive(true);
        stopButton.SetActive(false);
       
    }

    public void OnEnable()
    {
        if(BettingScript.instance.totalBet > 0)
        {
            enabled = true;
            spinButton.SetActive(false);
            stopButton.SetActive(true);
        }
                                    
    }

    

}
