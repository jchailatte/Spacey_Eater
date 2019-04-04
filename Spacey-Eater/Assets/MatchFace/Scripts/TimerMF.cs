using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerMF : MonoBehaviour
{
    // Start is called before the first frame update
    float timeLeft = 15;
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
        if (OverallContMF.didWin)
        {
            PlayerPrefs.SetInt("didWin", 1);
        }
        else
        {
            PlayerPrefs.SetInt("didWin", 0);
        }
        //when time runs out, return to main game screen
        Invoke("LoadMainGame", 0.5f);
    }
    // Load Level when time runs out
    void LoadMainGame()
    {
        SceneManager.LoadScene("Game");
    }
}
