using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1ObjectMovement : MonoBehaviour
{
    public float leftAndRightSpeed = 1f;
    public float topAndBottomSpeed = 1f;
    public float leftAndRightEdge = 5f;
    public float topAndBottomEdge = 2f;
    public float chanceToChangeDirection = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Basic Movement
        Vector2 pos = transform.position;
        pos.x += leftAndRightSpeed * Time.deltaTime;
        pos.y += topAndBottomSpeed * Time.deltaTime;
        transform.position = pos;

        //Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            leftAndRightSpeed = Mathf.Abs(leftAndRightSpeed); 
        }
        else if (pos.x > leftAndRightEdge)
        {
            leftAndRightSpeed = -Mathf.Abs(leftAndRightSpeed); 
        }
        //Changing direction
        if (pos.x < -topAndBottomEdge)
        {
            topAndBottomSpeed = Mathf.Abs(topAndBottomSpeed);
        }
        else if (pos.x > topAndBottomSpeed)
        {
            topAndBottomSpeed = -Mathf.Abs(topAndBottomSpeed);
        }
    }

    private void FixedUpdate()
    {
        //Changing Direction Randomly is now time-based
        if (Random.value < chanceToChangeDirection)
        {
            leftAndRightSpeed *= -1;
        }

        //Changing Direction Randomly is now time-based
        if (Random.value < chanceToChangeDirection)
        {
            topAndBottomSpeed *= -1; //Change direction
        }
    }
}
