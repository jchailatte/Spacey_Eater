using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{

    private static float gameTime;
    private Text timeGT;
    public float maxGameTime = 10f;
    private void Awake()
    {
        Text gt = this.GetComponent<Text>();
        gameTime = maxGameTime;
        gt.text = "" + (int)gameTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        Text gt = this.GetComponent<Text>();
        gt.text = "" + (int)gameTime;
        if (gameTime < 0)
        {
            //when time runs out, return to main game screen
            Invoke("LoadMainGame", 0.5f);
        }
    }

    // Load Level when time runs out
    void LoadMainGame()
    {
        SceneManager.LoadScene("Game");
    }
}
