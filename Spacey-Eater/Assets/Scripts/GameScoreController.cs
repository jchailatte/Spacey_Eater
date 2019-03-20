using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class GameScoreController : MonoBehaviour
{

    private static float score;
    private GameObject mainPlayer;

    //Use awake to find score
    private void Awake()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    //Update score
    public void UpdateScore()
    {
        Text gt = this.GetComponent<Text>();
        score = mainPlayer.transform.localScale.x * 10000f + 1;
        gt.text = "Score: " + (int)score;
    }
}
