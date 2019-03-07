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
        Vector3 pos = transform.position;
    }
}
