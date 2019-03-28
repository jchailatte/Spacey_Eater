using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{

    public Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        Debug.Log(buttonText.text);
        transform.parent.gameObject.GetComponent<OverallContMF>().checkAnswer(buttonText.text);
    }
}
