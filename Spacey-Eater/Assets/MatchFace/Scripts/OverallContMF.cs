using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverallContMF : MonoBehaviour
{

    string[] faces = new string[9] { ":)", "T_T", "-.-", ":*(", "XD", ":|", ":P", ":D", ":x" };
    string solution;
    int score;
    public Text scoreText;
    public Text solText;

    Dropdown[] canvasComponents;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        reset();
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
            scoreText.text = "Score: " + score;
            reset();
        }

        if(score >= 20)
        {
            Debug.Log("GAME WIN");
        }

    }

    void reset()
    {
        int random = Random.Range(0, 9);

        solution = faces[random];
        solText.text = solution;
    }
}
