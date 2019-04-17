using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flipPuzzleController : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    void Start()
    {
        Debug.Log("Start game");
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(pictures[0].rotation.z) == 0 &&
           Mathf.Round(pictures[1].rotation.z) == 0 &&
           Mathf.Round(pictures[2].rotation.z) == 0 &&
           Mathf.Round(pictures[3].rotation.z) == 0 &&
           Mathf.Round(pictures[4].rotation.z) == 0 &&
           Mathf.Round(pictures[5].rotation.z) == 0 )
        {
            TimerController.didWin = true;
            PlayerPrefs.SetInt("didWin", 1);
            //win game return to main game
            Debug.Log("Win Game");
            SceneManager.LoadScene("Game");
        }
    }
}
