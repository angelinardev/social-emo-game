using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
   [Header("Component")]
    public TextMeshProUGUI timerText;
    public GameObject GameOverUI;
    public GameObject MemoryGameCanvas;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header ("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Level Settings")]
    public bool isImpossible = false;


    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
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
            //Add if statement and bool to check if level is impossible
            if (isImpossible)
            {
                SceneSwitch.instance.ChangeNextScene(); //Change to next scene if this is the impossible level
            }
            else
            {
                //LoseCondition
                MemoryGameCanvas.SetActive(false);
                GameOverUI.SetActive(true);
            }
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
