using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class Start : MonoBehaviour
{
        public void Launch()
    {
        Application.LoadLevel("Game");
        PlayerPrefs.SetFloat("currentX", 0.01f);
        PlayerPrefs.SetFloat("currentY", 0.01f);
        PlayerPrefs.SetInt("didWin", -1);
        PlayerPrefs.SetInt("random", 0);
    }
        public void LaunchTutorial()
    {
        Application.LoadLevel("Tutorial");
    }

    public void ToLaunch()
    {
        Application.LoadLevel("Launch");
    }
}
