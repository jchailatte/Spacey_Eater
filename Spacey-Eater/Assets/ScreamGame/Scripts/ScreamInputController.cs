using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamInputController : MonoBehaviour
{
    //Audio Input referenced from: https://www.reddit.com/r/Unity3D/comments/49wuld/best_way_to_implement_microphone_input/
    AudioClip micInput;
    bool hasMic;
    public float sensitivity;
    bool didWin;
    GameObject inputVol;


    // Start is called before the first frame update
    void Start()
    {
        TimerController.didWin = false;
       inputVol = this.gameObject.transform.GetChild(1).gameObject;

        sensitivity = .95f;
        if (Microphone.devices.Length > 0)
        {
            micInput = Microphone.Start(Microphone.devices[0], true, 5, 44100);
            hasMic = true;
            Debug.Log("Microphone input is available");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get mic volume
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null) - (dec + 1); // null means the first microphone
        micInput.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));
        Debug.Log("Level is " + level);
        inputVol.transform.localScale = new Vector2(level, level);

        if (level > sensitivity)
        {
           didWin = true;
           Debug.Log("Did Win is " + didWin);
            TimerController.didWin = true;
        }
    }
}

