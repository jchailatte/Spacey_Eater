using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GrowthPlanetCreator : MonoBehaviour
{

    public float minSpawnTime = 1.1f;
    public float maxSpawnTime = 1.2f;
    public GameObject growthPlanetPrefab;
    private int spawnCounter = 0;

    // Start is called before the first frame update
    void Start()
    {


            Invoke("SpawnGPlanet", minSpawnTime);
            spawnCounter = spawnCounter - 1; 


    }



    void SpawnGPlanet()
    {
        Camera camera = Camera.main;
        Vector3 cameraPos = camera.transform.position;
        float xMax = camera.aspect * camera.orthographicSize;
        float xRange = camera.aspect * camera.orthographicSize * 1.75f;
        float yMax = camera.orthographicSize - 0.5f;
        float yRange = camera.aspect * camera.orthographicSize * 1.75f;

        Vector3 growthPlanetPos = new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax), cameraPos.y + Random.Range(yMax - yRange, yMax), growthPlanetPrefab.transform.position.z);
        Instantiate(growthPlanetPrefab, growthPlanetPos, Quaternion.identity);




            Invoke("SpawnGPlanet", Random.Range(minSpawnTime, maxSpawnTime));
            


       

    }


}
