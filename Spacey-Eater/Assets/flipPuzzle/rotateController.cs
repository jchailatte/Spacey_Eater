using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateController : MonoBehaviour
{
    void Start()
    {
        //Randomize start orientation
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            transform.Rotate(0f, 0f, 90f);
        }
        else if (random == 1)
        {
            transform.Rotate(0f, 0f, 180f);
        }
        else if (random == 2)
        {
            transform.Rotate(0f, 0f, 270f);
        }
    }
    private void OnMouseDown()
    {
        //Rotate on click
        transform.Rotate(0f, 0f, 90f);
        
    }
}
