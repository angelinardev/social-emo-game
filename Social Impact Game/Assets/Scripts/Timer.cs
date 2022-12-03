using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
   [Header("Component")]
   public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header ("Limit Settings")]
    public bool hasLimit;
    public float timerLimit; 


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            //disables this script
            enabled = false;
            //this is when we lose
        }

            SetTimerText();
    }
  
    private void SetTimerText()
    {
        //display minutes
        //int minutes = Mathf.FloorToInt(currentTime/60f);
        //int seconds = Mathf.FloorToInt(timerLimit - minutes * 60);

        int minutes = Mathf.FloorToInt(currentTime/60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        
        //set how many decimal points
        timerText.text = niceTime;
    }
}
