using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update
    public void Launch()
    {
        Application.LoadLevel("Game");
    }

    public void ToLaunch()
    {
        Application.LoadLevel("Launch");
    }
}
