using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerPlanet;

    private void LateUpdate()
    {
        transform.position = new Vector3(playerPlanet.position.x, playerPlanet.position.y, transform.position.z); 
    }
}
