using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 moveDirection;


    public GameObject plat;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;


        Vector3 target = moveDirection * moveSpeed + currentPosition;
        transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);

        EnforceBounds();
    }

    private void EnforceBounds()
    {
        // 1
        Vector3 newPosition = transform.position;
        Camera mainCamera = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        // 2
        float xDist = mainCamera.aspect * mainCamera.orthographicSize;
        float xMax = cameraPosition.x + xDist;
        float xMin = cameraPosition.x - xDist;

        // 3
        if (newPosition.x < xMin || newPosition.x > xMax)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
            moveDirection.x = -moveDirection.x;
        }
        float yMax = mainCamera.orthographicSize;

        if (newPosition.y-2 < -yMax || newPosition.y+2 > yMax)
        {
            newPosition.y = Mathf.Clamp(newPosition.y, -yMax, yMax);
            moveDirection.y = -moveDirection.y;
        }

        // 4
        transform.position = newPosition;
    }
}
