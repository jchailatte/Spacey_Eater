using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    public void Launch()
    {
        Application.LoadLevel("Game");
        PlayerPrefs.SetFloat("currentX", 0.01f);
        PlayerPrefs.SetFloat("currentY", 0.01f);
        PlayerPrefs.SetInt("didWin", -1); 


    }

    public void ToLaunch()
    {
        Application.LoadLevel("Launch");
    }
}
