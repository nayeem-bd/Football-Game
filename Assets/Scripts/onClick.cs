using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Button football, exitBtn, startBtn;
    public Text gameOverTxt, timeTxt, scoreTxt,resetText;
    public int cnt = 0;
    public int seconds = -1;
    public float starttime;

    void Start()
    {
        football.enabled = false;
        football.onClick.AddListener(TaskOnBallClick);
        exitBtn.onClick.AddListener(TaskOnExitBtn);
        startBtn.onClick.AddListener(TaskOnStartBtn);
        resetText.text = "Start";
        scoreTxt.text = "Score : " + cnt.ToString();
        timeTxt.text = "Time : 0.000000";
    }

    void TaskOnStartBtn()
    {
        seconds = 1;
        starttime = Time.time;
        football.enabled = true;
        cnt = 0;
        scoreTxt.text = "Score : " + cnt.ToString();
        gameOverTxt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(timer());
    }
    
    void TaskOnBallClick()
    {
        cnt++;
        scoreTxt.text = "Score : "+cnt.ToString();
        Debug.Log("Rifat Clicked " + cnt + " Times");
    }

    IEnumerator timer()
    {  
        if (seconds != -1)
        {
            float newTime = Time.time - starttime;
            if(newTime > 2)
            {
                gameOverTxt.text = "Game Over!";
                football.enabled = false;
                seconds = -1;
                startBtn.enabled = true;
                resetText.text = "Restart";
            }
            else
            {
                timeTxt.text = "Time : "+newTime.ToString();
                startBtn.enabled = false;
            
            }
        }

        yield return null;
    }
    void TaskOnExitBtn()
    {
        Application.Quit();
    }
}
