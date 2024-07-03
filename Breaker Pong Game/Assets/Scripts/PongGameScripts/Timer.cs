using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;

    // Update is called once per frame
    void Update()
    {
        CountDown();   
    }

    private void CountDown()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime ;
        }else if (remainingTime <= 0)
        {
            remainingTime = 0;
            BusSystem.GameOver();
            
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
