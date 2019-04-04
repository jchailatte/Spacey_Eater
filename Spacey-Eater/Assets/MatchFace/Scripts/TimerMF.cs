using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMF : MonoBehaviour
{
    // Start is called before the first frame update
    float timeLeft = 30;
    public Text timerText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft < 0)
        {
            GameOver();
        }
        else
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.RoundToInt(timeLeft);
        }
    }

    void GameOver()
    {
        Debug.Log("GameOVER");
    }
}
