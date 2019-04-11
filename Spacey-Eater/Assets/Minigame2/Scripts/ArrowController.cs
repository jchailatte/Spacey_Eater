using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    float x = 0;
    float z = 0;
    GameObject leftArrow;
    GameObject upArrow;
    GameObject downArrow;
    GameObject rightArrow;
    int arrowNum = 1;
    private int random;
    private int score;
    private float threshold; 


    // Start is called before the first frame update
    void Start()
    {
        leftArrow = this.gameObject.transform.GetChild(0).gameObject;//0
        upArrow = this.gameObject.transform.GetChild(1).gameObject;//1
        downArrow = this.gameObject.transform.GetChild(2).gameObject;//2
        rightArrow = this.gameObject.transform.GetChild(3).gameObject;//3

        changeArrow();

        score = 0;
        threshold = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        //Add accleration
        x += -Input.acceleration.y;
        z += Input.acceleration.x;

        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Up arrow input");
                z = 20f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Down arrow input");
                z = -20f;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Debug.Log("Left arrow input");
                x = 20f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Debug.Log("Right arrow input");
                x = -20f;
            }
        }
        switch (arrowNum)
        {
            case 1:
                if (x < -threshold)
                {
                    score++;
                    changeArrow();
                }
                break;
            case 2:
                if (x > threshold)
                {
                    score++;
                    changeArrow();
                }
                break;
            case 3:
                if (z < -threshold)
                {
                    score++;
                    changeArrow();
                }
                break;
            case 4:
                if (z > threshold)
                {
                    score++;
                    changeArrow();
                }
                break;
            default:
                break;
        }
        //Send winning result to timer controller
        if (score > 4)
        {
            TimerController.didWin = true;
        }
        else
        {
            TimerController.didWin = false;
        }
    }

    void changeArrow()
    {
        //Reset Accelerometer
        x = 0;
        z = 0;
        //Commenting to discard randomness during testing
        random = Random.Range(1, 5);
        Debug.Log("Random number is:" + random);

        leftArrow.SetActive(false);
        upArrow.SetActive(false);
        downArrow.SetActive(false);
        rightArrow.SetActive(false);

        switch (random)
        {
            case 1:
                leftArrow.SetActive(true);
                arrowNum = 1;//1
                break;
            case 2:
                rightArrow.SetActive(true);
                arrowNum = 2;//2
                break;
            case 3:
                downArrow.SetActive(true);
                arrowNum = 3;//3
                break;
            case 4:
                upArrow.SetActive(true);
                arrowNum = 4;//4
                break;
            default:
                Debug.Log("Switch Error");
                break;
        }

    }
}



//left is up, right is down, up is right, down is left 