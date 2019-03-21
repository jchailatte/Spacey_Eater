using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerPlanet;

    public GameObject planet;

    public Camera thiscam;

    public float viewWidth, viewHeight;

    private void Start()
    { 
        thiscam.enabled = true;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(playerPlanet.position.x, playerPlanet.position.y, transform.position.z); 
    }

    void Update()
    {
        if(thiscam)
        {
            thiscam.orthographic = true;
            float temp = (float)planet.transform.localScale.x;
            thiscam.orthographicSize = 1.0f + (20.0f * temp);
        }
    }
}
