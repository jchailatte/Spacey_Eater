using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Transform player;
    public float maxBound;
    public float minBound;

    private Vector3 moveDirection;
    public float moveSpeed;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private bool didFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        fireRate = 0.5f;
    }

    // Update is called once per frame
    void Update() 
    {
        didFire = false;
        Vector3 currentPosition = transform.position;
        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("mouse fired");
            Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveDirection = moveToward - currentPosition;
            Debug.Log("y direction is: " + moveDirection.y);
            if (moveDirection.y > 4)
            {
                didFire = true;
            }
            
            moveDirection.y = 0;
            moveDirection.z = 0;
            moveDirection.Normalize();
        }
        if (player.position.x < minBound && moveDirection.x < 0)
        {
            moveDirection.x = 0;
        }
        else if (player.position.x > maxBound && moveDirection.x > 0)
        {
            moveDirection.x = 0;
        }
        Vector3 target = moveDirection * moveSpeed + currentPosition;
        transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);

        if (Time.time > nextFire && didFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
