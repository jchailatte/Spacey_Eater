using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OverallContMF : MonoBehaviour
{

    string[] faces = new string[9] { ":)", "T_T", "-.-", ":*(", "XD", ":|", ":P", ":D", ":x" };
    string solution;
    int score;
    public Text scoreText;
    public Text solText;
    public static bool didWin;

    Dropdown[] canvasComponents;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        reset();
        StartCoroutine(Blink());
    }

    public IEnumerator Blink()
    {
        while(true)
        {
            solText.text = "";
            yield return new WaitForSeconds(0.7f);
            solText.text = solution;
            yield return new WaitForSeconds(0.7f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void checkAnswer(string answer)
    {

        Debug.Log(answer);
        bool flag = true;

        if(answer == solution)
        {
            score++;
            scoreText.text = "Score: " + score+"/10";
            reset();
        }

        if(score >= 10)
        {
            TimerController.didWin = true;
            PlayerPrefs.SetInt("didWin", 1);
            //win game return to main game
            Debug.Log("Win Game");
            SceneManager.LoadScene("Game");
        }

    }

    void reset()
    {
        int random = Random.Range(0, 9);

        solution = faces[random];
        solText.text = solution;
    }
}
