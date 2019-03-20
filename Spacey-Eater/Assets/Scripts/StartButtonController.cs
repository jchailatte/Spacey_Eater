using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button startGame;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Buttons
        startGame = new Button();
        startGame.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("Start Game Button Clicked");

        //Reset original score
        PlayerPrefs.SetFloat("currentX", 0.01f);
        PlayerPrefs.SetFloat("currentY", 0.01f);
        PlayerPrefs.SetInt("didWin", -1);

        //when time runs out, return to main game screen
        Invoke("LoadMainGame", 0.5f);
    }

    // Load Level when time runs out
    void LoadMainGame()
    {
        SceneManager.LoadScene("Game");
    }
}
