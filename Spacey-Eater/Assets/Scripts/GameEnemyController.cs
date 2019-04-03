﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float speed = 2f;
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    public Rigidbody2D rb; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; 

        if(timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += accelerationTime; 
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed); 
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); 
    }
}
